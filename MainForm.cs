using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Text;
using System.Windows.Forms;
using LibreHardwareMonitor.Hardware;

namespace OledMonitor
{
    public partial class MainForm : Form
    {
        private readonly Computer _computer;
        private SerialPort? _serialPort;
        private readonly System.Windows.Forms.Timer _updateTimer = new();
        private readonly Dictionary<string, float> _sensorValues = new();
        private bool _autoUpdate = true;

        public MainForm()
        {
            InitializeComponent();

            // Initialize LibreHardwareMonitor
            _computer = new Computer
            {
                IsCpuEnabled = true,
                IsGpuEnabled = true,
                IsMemoryEnabled = true,
                IsMotherboardEnabled = true,
                IsControllerEnabled = false,
                IsNetworkEnabled = false,
                IsStorageEnabled = false
            };
            _computer.Open();

            // Find available serial ports
            RefreshComPorts();

            // Setup timer for updates
            _updateTimer.Interval = 1000; // 1 second updates
            _updateTimer.Tick += UpdateTimer_Tick;

            // Add sensor variable examples to help text
            UpdateHelpText();
        }

        private void UpdateHelpText()
        {
            // Collect available sensors to show as examples
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Available sensor variables:");
            sb.AppendLine();

            // Update hardware readings
            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update();

                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.Value.HasValue &&
                        (sensor.SensorType == SensorType.Load ||
                         sensor.SensorType == SensorType.Temperature ||
                         sensor.SensorType == SensorType.Clock ||
                         sensor.SensorType == SensorType.Power))
                    {
                        string sensorId = GetSensorVariableName(hardware.Name, sensor.Name);
                        _sensorValues[sensorId] = sensor.Value.Value;

                        string unit = GetSensorUnit(sensor.SensorType);
                        sb.AppendLine($"{sensorId} = {sensor.Value.Value:F1}{unit}");
                    }
                }
            }

            txtHelpText.Text = sb.ToString();
        }

        private string GetSensorVariableName(string hardwareName, string sensorName)
        {
            // Create a simplified and safe variable name
            string name = $"{hardwareName}_{sensorName}"
                .Replace(" ", "_")
                .Replace("%", "Percent")
                .Replace("#", "Num")
                .Replace("/", "_")
                .Replace("\\", "_")
                .Replace("(", "")
                .Replace(")", "")
                .Replace(",", "");

            return name;
        }

        private string GetSensorUnit(SensorType sensorType)
        {
            return sensorType switch
            {
                SensorType.Temperature => "°C",
                SensorType.Load => "%",
                SensorType.Clock => "MHz",
                SensorType.Power => "W",
                _ => ""
            };
        }

        private void RefreshComPorts()
        {
            comboBoxPorts.Items.Clear();
            foreach (string port in SerialPort.GetPortNames())
            {
                comboBoxPorts.Items.Add(port);
            }

            if (comboBoxPorts.Items.Count > 0)
                comboBoxPorts.SelectedIndex = 0;
        }

        private void btnConnect_Click(object? sender, EventArgs e)
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                DisconnectFromDevice();
                btnConnect.Text = "Connect";
                lblStatus.Text = "Disconnected";
                _updateTimer.Stop();
            }
            else
            {
                try
                {
                    string selectedPort = comboBoxPorts.SelectedItem?.ToString() ?? "";
                    if (string.IsNullOrEmpty(selectedPort))
                    {
                        MessageBox.Show("Please select a COM port.");
                        return;
                    }

                    _serialPort = new SerialPort(selectedPort, 115200);
                    _serialPort.Open();
                    btnConnect.Text = "Disconnect";
                    lblStatus.Text = $"Connected to {selectedPort}";
                    _updateTimer.Start();

                    // Send immediately after connecting
                    SendMarkupToDevice();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error connecting to device: {ex.Message}");
                }
            }
        }

        private void DisconnectFromDevice()
        {
            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.Close();
                _serialPort.Dispose();
                _serialPort = null;
            }
        }

        private void UpdateTimer_Tick(object? sender, EventArgs e)
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                return;

            // Update all hardware readings
            UpdateSensorValues();

            // If set to auto-update, send markup to device
            if (_autoUpdate)
            {
                SendMarkupToDevice();
            }
        }

        private void UpdateSensorValues()
        {
            // Update all hardware readings
            foreach (var hardware in _computer.Hardware)
            {
                hardware.Update();

                foreach (var sensor in hardware.Sensors)
                {
                    if (sensor.Value.HasValue)
                    {
                        string sensorId = GetSensorVariableName(hardware.Name, sensor.Name);
                        _sensorValues[sensorId] = sensor.Value.Value;
                    }
                }
            }
        }

        private void SendMarkupToDevice()
        {
            if (_serialPort == null || !_serialPort.IsOpen)
                return;

            try
            {
                string markup = ProcessVariablesInMarkup(txtMarkupEditor.Text);
                _serialPort.WriteLine(markup);
                txtMarkupPreview.Text = markup;
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
                _updateTimer.Stop();
                DisconnectFromDevice();
                btnConnect.Text = "Connect";
            }
        }

        private string ProcessVariablesInMarkup(string markup)
        {
            // Replace variables with actual values
            foreach (var sensor in _sensorValues)
            {
                // Look for {variable} syntax in the markup
                string variablePattern = $"{{{sensor.Key}}}";

                // Format value based on type (integers vs decimals)
                string formattedValue;
                if (Math.Abs(sensor.Value - Math.Round(sensor.Value)) < 0.01)
                {
                    formattedValue = $"{sensor.Value:F0}";
                }
                else
                {
                    formattedValue = $"{sensor.Value:F1}";
                }

                markup = markup.Replace(variablePattern, formattedValue);
            }

            return markup;
        }

        private void btnRefreshPorts_Click(object? sender, EventArgs e)
        {
            RefreshComPorts();
        }

        private void btnRefreshSensors_Click(object? sender, EventArgs e)
        {
            UpdateSensorValues();
            UpdateHelpText();
        }

        private void btnSendNow_Click(object? sender, EventArgs e)
        {
            UpdateSensorValues();
            SendMarkupToDevice();
        }

        private void chkAutoUpdate_CheckedChanged(object? sender, EventArgs e)
        {
            _autoUpdate = chkAutoUpdate.Checked;
        }

        private void Form_FormClosing(object? sender, FormClosingEventArgs e)
        {
            _updateTimer.Stop();
            DisconnectFromDevice();
            _computer.Close();
        }

        private void btnLoadExample_Click(object? sender, EventArgs e)
        {
            txtMarkupEditor.Text =
                "<text x=0 y=12 size=1>CPU: {CPU_Core_i7-6700K_Total_Load}%</text>" +
                "<bar x=0 y=16 w=100 h=8 val={CPU_Core_i7-6700K_Total_Load} />" +
                "<text x=0 y=32 size=1>GPU: {GPU_NVIDIA_GeForce_GTX_1080_Load_GPU_Core}%</text>" +
                "<bar x=0 y=36 w=100 h=8 val={GPU_NVIDIA_GeForce_GTX_1080_Load_GPU_Core} />" +
                "<text x=0 y=52 size=1>RAM: {Memory_Load}%</text>" +
                "<bar x=0 y=56 w=100 h=8 val={Memory_Load} />";
        }

        private void btnInsertIcon_Click(object? sender, EventArgs e)
        {
            using IconBrowser browser = new();
            if (browser.ShowDialog() == DialogResult.OK)
            {
                // Get the icon markup and insert it at the cursor position
                string iconMarkup = browser.GetIconMarkup();
                if (!string.IsNullOrEmpty(iconMarkup))
                {
                    int selectionStart = txtMarkupEditor.SelectionStart;
                    txtMarkupEditor.Text = txtMarkupEditor.Text.Insert(selectionStart, iconMarkup);
                    txtMarkupEditor.SelectionStart = selectionStart + iconMarkup.Length;
                    txtMarkupEditor.Focus();
                }
            }
        }
    }
}