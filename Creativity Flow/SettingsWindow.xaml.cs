using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Runtime.InteropServices; // for using *.ini files from lib kernel32.dll


/*
 * TODO NORMAL:
 * profile settings
 */

namespace Creativity_Flow
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        //bool applyPermission = true;

     // profiles
        string profile = MainWindow.profile;
        string profilesSettingsPath = MainWindow.profilesSettingsPath;
        string programSettingsPath = MainWindow.programSettingsPath;


        bool startType;
        public int timeBeforeStart;
                
        bool erasingModeSwitch;
        public int timeBeforeErasing;
        string erasingType;
        string erasingFunction;
        public int erasingSpeed;
        
        bool soundSignalSwitch;
        bool visualSignalSwitch;
        bool backspaceSwitch;
        bool pointerSwitch;
        bool hiderSwitch;

        bool emergencyStoperSwitch;
        bool emergencyHiderSwitch;
        bool emergencyStopLimiterSwitch;
        int emergencyStopLimit;
        bool emergencyStopPermissionTimerSwitch;
        int emergencyStopPermissionTime;

        bool stopPermissionTimerSwitch;
        public int stopPermissionTime;
        bool autoSaveAfterStopPermissionSwitch;


        // using *.ini stuff metods. need to save settings with program to make it portable // maybe i will use it in settings window // TODO make settings saver
        [DllImport("kernel32.dll", EntryPoint = "GetPrivateProfileString")] // to get value from *.ini file
        private static extern int GetPrivateString(string section, string key, string def, StringBuilder buffer, int size, string path); // use: def = null, size = 1024, path = "./profiles.ini"; buffer.ToString() give value for us
        [DllImport("kernel32.dll", EntryPoint = "WritePrivateProfileString")]  // to set value in *.ini file
        private static extern int WritePrivateString(string section, string key, string str, string path);


        public SettingsWindow()
        {
            InitializeComponent();


            

            PreSet();

            

            
        }

        /////////////////////////////////////////////////////////////////////////////////////////// controls

        /// <summary>
        ///  Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void StartWithSymbolRB_Click(object sender, RoutedEventArgs e)
        {
            startType = true;
                        
            timeBeforeStartTB.IsEnabled = false;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void StartWithCountRB_Click(object sender, RoutedEventArgs e)
        {
            startType = false;

            timeBeforeStartTB.IsEnabled = true;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        private void TimeBeforeStartTB_KeyUp(object sender, KeyEventArgs e)
        {
            TextBoxNumberEnter(ref timeBeforeStart, ref timeBeforeStartTB);
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void ErasingModeSwitchCB_Checked(object sender, RoutedEventArgs e)
        {
            erasingModeSwitch = true;

            timeBeforeErasingTB.IsEnabled = true;
            erasingTypeCB.IsEnabled = true;
            erasingFunctionCB.IsEnabled = true;
            erasingSpeedTB.IsEnabled = true;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void ErasingModeSwitchCB_Unchecked(object sender, RoutedEventArgs e)
        {
            erasingModeSwitch = false;

            timeBeforeErasingTB.IsEnabled = false;
            erasingTypeCB.IsEnabled = false;
            erasingFunctionCB.IsEnabled = false;
            erasingSpeedTB.IsEnabled = false;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        private void TimeBeforeErasingTB_KeyUp(object sender, KeyEventArgs e)
        {
            TextBoxNumberEnter(ref timeBeforeErasing, ref timeBeforeErasingTB);
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="SelectionChangedEventArgs" /> instance containing the event data.
        /// </param>
        private void ErasingTypeCB_Selected(object sender, SelectionChangedEventArgs e)
        {
            erasingType = erasingTypeCB.Text;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="SelectionChangedEventArgs" /> instance containing the event data.
        /// </param>
        private void ErasingFunctionCB_Selected(object sender, SelectionChangedEventArgs e)
        {
            erasingFunction = erasingFunctionCB.Text;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        private void ErasingSpeedTB_KeyUp(object sender, KeyEventArgs e)
        {
            TextBoxNumberEnter(ref erasingSpeed, ref erasingSpeedTB);
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void BlockStopCB_Checked(object sender, RoutedEventArgs e)
        {
            stopPermissionTimerSwitch = true;

            blockStopTimeInSecondsTB.IsEnabled = true;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void BlockStopCB_Unchecked(object sender, RoutedEventArgs e)
        {
            stopPermissionTimerSwitch = false;

            blockStopTimeInSecondsTB.IsEnabled = false;
        }

        /// <summary>
        /// Control event for settings changeing.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="KeyEventArgs" /> instance containing the event data.
        /// </param>
        private void BlockStopTimeTB_KeyUp(object sender, KeyEventArgs e)
        {
            TextBoxNumberEnter(ref stopPermissionTime, ref blockStopTimeInSecondsTB);
        }

        /////////////////////////////////////////////////////////////////////////////////////////// buttons
        /// <summary>
        /// Handles the Click event of the applyB control.
        /// Used to save all settings in ini file.
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void ApplyB_Click(object sender, RoutedEventArgs e)
        {            
            WritePrivateString(profile, "startType", startType.ToString(), profilesSettingsPath);
            WritePrivateString(profile, "timeBeforeStart", timeBeforeStart.ToString(), profilesSettingsPath);

            WritePrivateString(profile, "erasingModeSwitch", erasingModeSwitch.ToString(), profilesSettingsPath);
            WritePrivateString(profile, "timeBeforeErasing", timeBeforeErasing.ToString(), profilesSettingsPath);
            WritePrivateString(profile, "erasingType", erasingType.ToString(), profilesSettingsPath);
            WritePrivateString(profile, "erasingFunction", erasingFunction.ToString(), profilesSettingsPath);
            WritePrivateString(profile, "erasingSpeed", erasingSpeed.ToString(), profilesSettingsPath);

            WritePrivateString(profile, "stopPermissionTimerSwitch", stopPermissionTimerSwitch.ToString(), profilesSettingsPath);
            WritePrivateString(profile, "stopPermissionTime", stopPermissionTime.ToString(), profilesSettingsPath);


             this.Close();
        }

        /// <summary>
        /// Handles the Click event of the cancelB control.
        /// Only close SettingsWindow
        /// </summary>
        /// <param name="sender">
        /// The source of the event.
        /// </param>
        /// <param name="e">
        /// The <see cref="RoutedEventArgs" /> instance containing the event data.
        /// </param>
        private void CancelB_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /////////////////////////////////////////////////////////////////////////////////////////// other

        /// <summary>
        /// Method, that helps to set all controls with values from ini file.
        /// </summary>
        private void PreSet()
        {
            if (File.Exists(profilesSettingsPath))
            {                
                StringBuilder buffer = new StringBuilder(255);

                GetPrivateString(profile, "startType", null, buffer, 255, profilesSettingsPath);

                if (buffer.ToString() == "True")
                {
                    StartWithSymbolRB_Click(startWithSymbolRB, new RoutedEventArgs());
                    startWithSymbolRB.IsChecked = true;
                    startWithCountRB.IsChecked = false;
                }
                else
                {
                    StartWithCountRB_Click(startWithCountRB, new RoutedEventArgs());
                    startWithCountRB.IsChecked = true;
                    startWithSymbolRB.IsChecked = false;
                }


                GetPrivateString(profile, "timeBeforeStart", null, buffer, 255, profilesSettingsPath);

                timeBeforeStartTB.Text = buffer.ToString();


                TextBoxNumberEnter(ref timeBeforeStart, ref timeBeforeStartTB);


                GetPrivateString(profile, "erasingModeSwitch", null, buffer, 255, profilesSettingsPath);

                if (buffer.ToString() == "True")
                {
                    ErasingModeSwitchCB_Checked(erasingModeSwitchCB, new RoutedEventArgs());
                    erasingModeSwitchCB.IsChecked = true;
                }
                else
                {
                    ErasingModeSwitchCB_Unchecked(erasingModeSwitchCB, new RoutedEventArgs());
                    erasingModeSwitchCB.IsChecked = false;
                }


                GetPrivateString(profile, "timeBeforeErasing", null, buffer, 255, profilesSettingsPath);

                timeBeforeErasingTB.Text = buffer.ToString();

                TextBoxNumberEnter(ref timeBeforeErasing, ref timeBeforeErasingTB);


                GetPrivateString(profile, "erasingType", null, buffer, 255, profilesSettingsPath);

                erasingTypeCB.SelectedItem = buffer.ToString();

                erasingType = erasingTypeCB.Text;


                GetPrivateString(profile, "erasingFunction", null, buffer, 255, profilesSettingsPath);

                erasingFunctionCB.SelectedItem = buffer.ToString();

                erasingFunction = erasingFunctionCB.Text;


                GetPrivateString(profile, "erasingSpeed", null, buffer, 255, profilesSettingsPath);

                erasingSpeedTB.Text = buffer.ToString();

                TextBoxNumberEnter(ref erasingSpeed, ref erasingSpeedTB);


                GetPrivateString(profile, "stopPermissionTimerSwitch", null, buffer, 255, profilesSettingsPath);

                if (buffer.ToString() == "True")
                {
                    BlockStopCB_Checked(blockStopCB, new RoutedEventArgs());
                    blockStopCB.IsChecked = true;
                }
                else
                {
                    BlockStopCB_Unchecked(blockStopCB, new RoutedEventArgs());
                    blockStopCB.IsChecked = false;
                }


                GetPrivateString(profile, "stopPermissionTime", null, buffer, 255, profilesSettingsPath);

                blockStopTimeInSecondsTB.Text = buffer.ToString();

                TextBoxNumberEnter(ref stopPermissionTime, ref timeBeforeErasingTB);

            }
            else { MessageBox.Show("Profiles settings NOT found!"); }
        }

        /// <summary>
        /// Helps to control state of controls and buttons depending on data entered.
        /// </summary>
        /// <param name="var">
        /// The variable.
        /// </param>
        /// <param name="sender">
        /// The sender.
        /// </param>
        public void TextBoxNumberEnter(ref int var, ref TextBox sender)
        {            
            if (SettingsLogic.TextCheck(ref var, sender.Text.ToString()))
            {
                sender.Background = Brushes.White;
            }
            else
            {
                sender.Background = Brushes.Red;
            }

            if (SettingsLogic.ApplyActivation(ref timeBeforeStart, ref timeBeforeErasing, ref erasingSpeed, ref stopPermissionTime))
            {
                applyB.IsEnabled = true;
            }
            else
            {
                applyB.IsEnabled = false;
            }
            


            
        }
    }
}
