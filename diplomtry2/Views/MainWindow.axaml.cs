using Avalonia.Controls;
using Avalonia.Interactivity;
using System.IO;
using diplomtry2.ViewModels;
using Avalonia.Media;
using System;

namespace diplomtry2.Views;

public partial class MainWindow : Window
{        
    int walls_count = 0;
    int windows_count = 0;
    int radiators_count = 0;
    int doors_count = 0;
    double[] freq_array = new double[21];


    public MainWindow()
    {
        InitializeComponent();
        load_elements();        
    }
    
    #region Автозаполнение материалов стен
    private void comboBox_FirstWallMaterial_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FirstWallimageselector();
            comboBox_FirstWallMaterial_par.SelectedIndex = comboBox_FirstWallMaterial.SelectedIndex;  
            FirstWallMaterial_par1.Text = comboBox_FirstWallMaterial_par.SelectedItem.ToString().Split(' ')[1];
            FirstWallMaterial_par2.Text = comboBox_FirstWallMaterial_par.SelectedItem.ToString().Split(' ')[2];
            
        }
        catch { }
       
    }

    private void comboBox_SecondWallMaterial_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            SecondWallimageselector();
            comboBox_SecondWallMaterial_par.SelectedIndex = comboBox_SecondWallMaterial.SelectedIndex;
            SecondWallMaterial_par1.Text = comboBox_SecondWallMaterial_par.SelectedItem.ToString().Split(' ')[1];
            SecondWallMaterial_par2.Text = comboBox_SecondWallMaterial_par.SelectedItem.ToString().Split(' ')[2];
        }
        catch { }

    }

    private void comboBox_ThirdWallMaterial_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ThirdWallimageselector();
            comboBox_ThirdWallMaterial_par.SelectedIndex = comboBox_ThirdWallMaterial.SelectedIndex;
            ThirdWallMaterial_par1.Text = comboBox_ThirdWallMaterial_par.SelectedItem.ToString().Split(' ')[1];
            ThirdWallMaterial_par2.Text = comboBox_ThirdWallMaterial_par.SelectedItem.ToString().Split(' ')[2];
        }
        catch { }

    }

    private void comboBox_FourthWallMaterial_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FourthWallimageselector();
            comboBox_FourthWallMaterial_par.SelectedIndex = comboBox_FourthWallMaterial.SelectedIndex;
            FourthWallMaterial_par1.Text = comboBox_FourthWallMaterial_par.SelectedItem.ToString().Split(' ')[1];
            FourthWallMaterial_par2.Text = comboBox_FourthWallMaterial_par.SelectedItem.ToString().Split(' ')[2];
        }
        catch { }

    }
    #endregion

    #region Автозаполнение батарей
    private void comboBox_FirstWallRadiator_Changed(object sender, SelectionChangedEventArgs e) 
    {
        try
        {
            FirstWallimageselector();
            comboBox_FirstWallRadiator_par.SelectedIndex = comboBox_FirstWallRadiator.SelectedIndex;
            FirstWallRadiator_par1.Text = comboBox_FirstWallRadiator_par.SelectedItem.ToString().Split(' ')[1];
            FirstWallRadiator_par2.Text = comboBox_FirstWallRadiator_par.SelectedItem.ToString().Split(' ')[2];
            FirstWallOversizeChecker();


        }
        catch { }
    }

    private void comboBox_SecondWallRadiator_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            SecondWallimageselector();
            comboBox_SecondWallRadiator_par.SelectedIndex = comboBox_SecondWallRadiator.SelectedIndex;
            SecondWallRadiator_par1.Text = comboBox_SecondWallRadiator_par.SelectedItem.ToString().Split(' ')[1];
            SecondWallRadiator_par2.Text = comboBox_SecondWallRadiator_par.SelectedItem.ToString().Split(' ')[2];
            SecondWallOversizeChecker();
        }
        catch { }
    }

    private void comboBox_ThirdWallRadiator_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ThirdWallimageselector();
            comboBox_ThirdWallRadiator_par.SelectedIndex = comboBox_ThirdWallRadiator.SelectedIndex;
            ThirdWallRadiator_par1.Text = comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Split(' ')[1];
            ThirdWallRadiator_par2.Text = comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Split(' ')[2];
            ThirdWallOversizeChecker();
        }
        catch { }
    }

    private void comboBox_FourthWallRadiator_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FourthWallimageselector();
            comboBox_FourthWallRadiator_par.SelectedIndex = comboBox_FourthWallRadiator.SelectedIndex;
            FourthWallRadiator_par1.Text = comboBox_FourthWallRadiator_par.SelectedItem.ToString().Split(' ')[1];
            FourthWallRadiator_par2.Text = comboBox_FourthWallRadiator_par.SelectedItem.ToString().Split(' ')[2];
            FourthWallOversizeChecker();
        }
        catch { }
    }
    #endregion

    #region Автозаполнение окон
    private void comboBox_FirstWallWindow_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FirstWallimageselector();
            comboBox_FirstWallWindow_par.SelectedIndex = comboBox_FirstWallWindow.SelectedIndex;
            FirstWallWindow_par1.Text = comboBox_FirstWallWindow_par.SelectedItem.ToString().Split(' ')[1];
            FirstWallWindow_par2.Text = comboBox_FirstWallWindow_par.SelectedItem.ToString().Split(' ')[2];
            FirstWallOversizeChecker();
        }
        catch
        { }
    }

    private void comboBox_SecondWallWindow_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            SecondWallimageselector();
            comboBox_SecondWallWindow_par.SelectedIndex = comboBox_SecondWallWindow.SelectedIndex;
            SecondWallWindow_par1.Text = comboBox_SecondWallWindow_par.SelectedItem.ToString().Split(' ')[1];
            SecondWallWindow_par2.Text = comboBox_SecondWallWindow_par.SelectedItem.ToString().Split(' ')[2];
            SecondWallOversizeChecker();
        }
        catch
        { }
    }

    private void comboBox_ThirdWallWindow_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ThirdWallimageselector();
            comboBox_ThirdWallWindow_par.SelectedIndex = comboBox_ThirdWallWindow.SelectedIndex;
            ThirdWallWindow_par1.Text = comboBox_ThirdWallWindow_par.SelectedItem.ToString().Split(' ')[1];
            ThirdWallWindow_par2.Text = comboBox_ThirdWallWindow_par.SelectedItem.ToString().Split(' ')[2];
            ThirdWallOversizeChecker();
        }
        catch
        { }
    }

    private void comboBox_FourthWallWindow_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FourthWallimageselector();
            comboBox_FourthWallWindow_par.SelectedIndex = comboBox_FourthWallWindow.SelectedIndex;
            FourthWallWindow_par1.Text = comboBox_FourthWallWindow_par.SelectedItem.ToString().Split(' ')[1];
            FourthWallWindow_par2.Text = comboBox_FourthWallWindow_par.SelectedItem.ToString().Split(' ')[2];
            FourthWallOversizeChecker();
        }
        catch
        { }
    }
    #endregion

    #region Автозаполнение дверей
    private void comboBox_FirstWallDoor_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FirstWallimageselector();
            comboBox_FirstWallDoor_par.SelectedIndex = comboBox_FirstWallDoor.SelectedIndex;
            FirstWallDoor_par1.Text = comboBox_FirstWallDoor_par.SelectedItem.ToString().Split(' ')[1];
            FirstWallDoor_par2.Text = comboBox_FirstWallDoor_par.SelectedItem.ToString().Split(' ')[2];
            FirstWallOversizeChecker();
        }
        catch
        { }
    }
    
    private void comboBox_SecondWallDoor_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            SecondWallimageselector();
            comboBox_SecondWallDoor_par.SelectedIndex = comboBox_SecondWallDoor.SelectedIndex;
            SecondWallDoor_par1.Text = comboBox_SecondWallDoor_par.SelectedItem.ToString().Split(' ')[1];
            SecondWallDoor_par2.Text = comboBox_SecondWallDoor_par.SelectedItem.ToString().Split(' ')[2];
            SecondWallOversizeChecker();
        }
        catch
        { }
    }

    private void comboBox_ThirdWallDoor_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            ThirdWallimageselector();
            comboBox_ThirdWallDoor_par.SelectedIndex = comboBox_ThirdWallDoor.SelectedIndex;
            ThirdWallDoor_par1.Text = comboBox_ThirdWallDoor_par.SelectedItem.ToString().Split(' ')[1];
            ThirdWallDoor_par2.Text = comboBox_ThirdWallDoor_par.SelectedItem.ToString().Split(' ')[2];
            ThirdWallOversizeChecker();
        }
        catch
        { }
    }

    private void comboBox_FourthWallDoor_Changed(object sender, SelectionChangedEventArgs e)
    {
        try
        {
            FourthWallimageselector();
            comboBox_FourthWallDoor_par.SelectedIndex = comboBox_FourthWallDoor.SelectedIndex;
            FourthWallDoor_par1.Text = comboBox_FourthWallDoor_par.SelectedItem.ToString().Split(' ')[1];
            FourthWallDoor_par2.Text = comboBox_FourthWallDoor_par.SelectedItem.ToString().Split(' ')[2];
            FourthWallOversizeChecker();
        }
        catch
        { }
    }
    #endregion
    
    #region Дополнительные феункции
    private void FirstWallOversizeChecker()
    {
        if ((comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FirstWallRadiator_par2.Text = "0,5";
                    FirstWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                FirstWallRadiator_par2.Text = comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                FirstWallDoor_par2.Text = comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FirstWallRadiator_par2.Text = "0,5";
                    FirstWallWindow_par2.Text = "0,5";
                }
            }
            catch
            {
                FirstWallRadiator_par2.Text = comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                FirstWallWindow_par2.Text = comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FirstWallDoor_par2.Text = "0,33";
                    FirstWallRadiator_par2.Text = "0,33";
                    FirstWallWindow_par2.Text = "0,33";
                }
            }
            catch
            {
                FirstWallRadiator_par2.Text = comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FirstWallWindow_par2.Text = "0,5";
                    FirstWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                FirstWallWindow_par2.Text = comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                FirstWallDoor_par2.Text = comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else
        {
            FirstWallRadiator_par2.Text = comboBox_FirstWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            FirstWallWindow_par2.Text = comboBox_FirstWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            FirstWallDoor_par2.Text = comboBox_FirstWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
        }            
    }

    private void SecondWallOversizeChecker()
    {
        if ((comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-"))
            try
            {
                if (Convert.ToDouble(comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    SecondWallRadiator_par2.Text = "0,5";
                    SecondWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                SecondWallRadiator_par2.Text = comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                SecondWallDoor_par2.Text = comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    SecondWallRadiator_par2.Text = "0,5";
                    SecondWallWindow_par2.Text = "0,5";
                }
            }
            catch
            {
                SecondWallRadiator_par2.Text = comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                SecondWallWindow_par2.Text = comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    SecondWallWindow_par2.Text = "0,5";
                    SecondWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                SecondWallWindow_par2.Text = comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                SecondWallDoor_par2.Text = comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    SecondWallDoor_par2.Text = "0,33";
                    SecondWallRadiator_par2.Text = "0,33";
                    SecondWallWindow_par2.Text = "0,33";
                }
            }
            catch
            {
                SecondWallRadiator_par2.Text = comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else
        {
            SecondWallRadiator_par2.Text = comboBox_SecondWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            SecondWallWindow_par2.Text = comboBox_SecondWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            SecondWallDoor_par2.Text = comboBox_SecondWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
        }
    }

    private void ThirdWallOversizeChecker()
    {
        if ((comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-"))
            try
            {
                if (Convert.ToDouble(comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    ThirdWallRadiator_par2.Text = "0,5";
                    ThirdWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                ThirdWallRadiator_par2.Text = comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                ThirdWallDoor_par2.Text = comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    ThirdWallRadiator_par2.Text = "0,5";
                    ThirdWallWindow_par2.Text = "0,5";
                }
            }
            catch
            {
                ThirdWallRadiator_par2.Text = comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                ThirdWallWindow_par2.Text = comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    ThirdWallWindow_par2.Text = "0,5";
                    ThirdWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                ThirdWallWindow_par2.Text = comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                ThirdWallDoor_par2.Text = comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    ThirdWallDoor_par2.Text = "0,33";
                    ThirdWallRadiator_par2.Text = "0,33";
                    ThirdWallWindow_par2.Text = "0,33";
                }
            }
            catch
            {
                ThirdWallRadiator_par2.Text = comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else
        {
            ThirdWallRadiator_par2.Text = comboBox_ThirdWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            ThirdWallWindow_par2.Text = comboBox_ThirdWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            ThirdWallDoor_par2.Text = comboBox_ThirdWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
        }
    }

    private void FourthWallOversizeChecker()
    {
        if ((comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FourthWallRadiator_par2.Text = "0,5";
                    FourthWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                FourthWallRadiator_par2.Text = comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                FourthWallDoor_par2.Text = comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FourthWallRadiator_par2.Text = "0,5";
                    FourthWallWindow_par2.Text = "0,5";
                }
            }
            catch
            {
                FourthWallRadiator_par2.Text = comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                FourthWallWindow_par2.Text = comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] == "-") && (comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FourthWallWindow_par2.Text = "0,5";
                    FourthWallDoor_par2.Text = "0,5";
                }
            }
            catch
            {
                FourthWallWindow_par2.Text = comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
                FourthWallDoor_par2.Text = comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else if ((comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-") && (comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2] != "-"))
            try
            {
                if (Convert.ToDouble(comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) + Convert.ToDouble(comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2]) >= 1)
                {
                    FourthWallDoor_par2.Text = "0,33";
                    FourthWallRadiator_par2.Text = "0,33";
                    FourthWallWindow_par2.Text = "0,33";
                }
            }
            catch
            {
                FourthWallRadiator_par2.Text = comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            }
        else
        {
            FourthWallRadiator_par2.Text = comboBox_FourthWallRadiator_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            FourthWallWindow_par2.Text = comboBox_FourthWallWindow_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
            FourthWallDoor_par2.Text = comboBox_FourthWallDoor_par.SelectedItem.ToString().Replace(".",",").Split(' ')[2];
        }
    }

    private void FirstWallimageselector()
    {
        FirstWallImage.IsVisible = false;
        FirstWallImageODR.IsVisible = false;
        FirstWallImageOD.IsVisible = false;
        FirstWallImageOR.IsVisible = false;
        FirstWallImageDR.IsVisible = false;
        FirstWallImageO.IsVisible = false;
        FirstWallImageD.IsVisible = false;
        FirstWallImageR.IsVisible = false;
        bool window, radiator, door;
        if (comboBox_FirstWallRadiator.SelectedIndex == 0)
        {
            radiator = false;
        }
        else
        {
            radiator = true;
        }
        if (comboBox_FirstWallWindow.SelectedIndex == 0)
        {
            window = false;
        }
        else
        {
            window = true;
        }
        if (comboBox_FirstWallDoor.SelectedIndex == 0)
        {
            door = false;
        }
        else
        {
            door = true;
        }
        if (window == true && door == true && radiator == true) { FirstWallImageODR.IsVisible = true; }
        else if (window == true && door == true && radiator == false) { FirstWallImageOD.IsVisible = true; }
        else if (window == true && door == false && radiator == true) { FirstWallImageOR.IsVisible = true; }
        else if (window == false && door == true && radiator == true) { FirstWallImageDR.IsVisible = true; }
        else if (window == true && door == false && radiator == false) { FirstWallImageO.IsVisible = true; }
        else if (window == false && door == true && radiator == false) { FirstWallImageD.IsVisible = true; }
        else if (window == false && door == false && radiator == true) { FirstWallImageR.IsVisible = true; }
        else if (window == false && door == false && radiator == false) { FirstWallImage.IsVisible = true; }

    }
   
    private void SecondWallimageselector()
    {
        SecondWallImage.IsVisible = false;
        SecondWallImageODR.IsVisible = false;
        SecondWallImageOD.IsVisible = false;
        SecondWallImageOR.IsVisible = false;
        SecondWallImageDR.IsVisible = false;
        SecondWallImageO.IsVisible = false;
        SecondWallImageD.IsVisible = false;
        SecondWallImageR.IsVisible = false;
        bool window, radiator, door;
        if (comboBox_SecondWallRadiator.SelectedIndex == 0)
        {
            radiator = false;
        }
        else
        {
            radiator = true;
        }
        if (comboBox_SecondWallWindow.SelectedIndex == 0)
        {
            window = false;
        }
        else
        {
            window = true;
        }
        if (comboBox_SecondWallDoor.SelectedIndex == 0)
        {
            door = false;
        }
        else
        {
            door = true;
        }
        if (window == true && door == true && radiator == true) { SecondWallImageODR.IsVisible = true; }
        else if (window == true && door == true && radiator == false) { SecondWallImageOD.IsVisible = true; }
        else if (window == true && door == false && radiator == true) { SecondWallImageOR.IsVisible = true; }
        else if (window == false && door == true && radiator == true) { SecondWallImageDR.IsVisible = true; }
        else if (window == true && door == false && radiator == false) { SecondWallImageO.IsVisible = true; }
        else if (window == false && door == true && radiator == false) { SecondWallImageD.IsVisible = true; }
        else if (window == false && door == false && radiator == true) { SecondWallImageR.IsVisible = true; }
        else if (window == false && door == false && radiator == false) { SecondWallImage.IsVisible = true; }

    }
    
    private void ThirdWallimageselector()
    {
        ThirdWallImage.IsVisible = false;
        ThirdWallImageODR.IsVisible = false;
        ThirdWallImageOD.IsVisible = false;
        ThirdWallImageOR.IsVisible = false;
        ThirdWallImageDR.IsVisible = false;
        ThirdWallImageO.IsVisible = false;
        ThirdWallImageD.IsVisible = false;
        ThirdWallImageR.IsVisible = false;
        bool window, radiator, door;
        if (comboBox_ThirdWallRadiator.SelectedIndex == 0)
        {
            radiator = false;
        }
        else
        {
            radiator = true;
        }
        if (comboBox_ThirdWallWindow.SelectedIndex == 0)
        {
            window = false;
        }
        else
        {
            window = true;
        }
        if (comboBox_ThirdWallDoor.SelectedIndex == 0)
        {
            door = false;
        }
        else
        {
            door = true;
        }
        if (window == true && door == true && radiator == true) { ThirdWallImageODR.IsVisible = true; }
        else if (window == true && door == true && radiator == false) { ThirdWallImageOD.IsVisible = true; }
        else if (window == true && door == false && radiator == true) { ThirdWallImageOR.IsVisible = true; }
        else if (window == false && door == true && radiator == true) { ThirdWallImageDR.IsVisible = true; }
        else if (window == true && door == false && radiator == false) { ThirdWallImageO.IsVisible = true; }
        else if (window == false && door == true && radiator == false) { ThirdWallImageD.IsVisible = true; }
        else if (window == false && door == false && radiator == true) { ThirdWallImageR.IsVisible = true; }
        else if (window == false && door == false && radiator == false) { ThirdWallImage.IsVisible = true; }

    }
    
    private void FourthWallimageselector()
    {
        FourthWallImage.IsVisible = false;
        FourthWallImageODR.IsVisible = false;
        FourthWallImageOD.IsVisible = false;
        FourthWallImageOR.IsVisible = false;
        FourthWallImageDR.IsVisible = false;
        FourthWallImageO.IsVisible = false;
        FourthWallImageD.IsVisible = false;
        FourthWallImageR.IsVisible = false;
        bool window, radiator, door;
        if (comboBox_FourthWallRadiator.SelectedIndex == 0)
        {
            radiator = false;
        }
        else
        {
            radiator = true;
        }
        if (comboBox_FourthWallWindow.SelectedIndex == 0)
        {
            window = false;
        }
        else
        {
            window = true;
        }
        if (comboBox_FourthWallDoor.SelectedIndex == 0)
        {
            door = false;
        }
        else
        {
            door = true;
        }
        if (window == true && door == true && radiator == true) { FourthWallImageODR.IsVisible = true; }
        else if (window == true && door == true && radiator == false) { FourthWallImageOD.IsVisible = true; }
        else if (window == true && door == false && radiator == true) { FourthWallImageOR.IsVisible = true; }
        else if (window == false && door == true && radiator == true) { FourthWallImageDR.IsVisible = true; }
        else if (window == true && door == false && radiator == false) { FourthWallImageO.IsVisible = true; }
        else if (window == false && door == true && radiator == false) { FourthWallImageD.IsVisible = true; }
        else if (window == false && door == false && radiator == true) { FourthWallImageR.IsVisible = true; }
        else if (window == false && door == false && radiator == false) { FourthWallImage.IsVisible = true; }

    }
    
    private void load_elements()
    {
        //string filePath = ".\\data.xam";
        string filePath = "C:\\Users\\glebm\\source\\repos\\diplomtry2\\diplomtry2\\Assets\\data.xam";
        using (StreamReader sr = File.OpenText(filePath))
        {
            bool walls_check = false;
            bool freq_check = false;
            bool windows_check = false;
            bool doors_check = false;
            bool radiators_check = false;
            string line;
            
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "--walls--")
                {
                    freq_check = false;
                    walls_check = true;
                    windows_check = false;
                    doors_check = false;
                    radiators_check = false;
                    continue;
                }
                if (line == "--windows--")
                {
                    freq_check = false;
                    walls_check = false;
                    windows_check = true;
                    doors_check = false;
                    radiators_check = false;
                    continue;
                }
                if (line == "--doors--")
                {
                    walls_check = false;
                    freq_check = false;
                    windows_check = false;
                    doors_check = true;
                    radiators_check = false;
                    continue;
                }
                if (line == "--radiators--")
                {
                    walls_check = false;
                    windows_check = false;
                    freq_check = false;
                    doors_check = false;
                    radiators_check = true;
                    continue;
                }
                if (line == "--end--")
                {
                    freq_check = false;
                    walls_check = false;
                    windows_check = false;
                    doors_check = false;
                    radiators_check = false;
                    break;
                }
                if (walls_check == true)
                {
                    walls_count++;
                    continue;
                }
                if (windows_check == true)
                {
                    windows_count++;
                    continue;
                }
                if (doors_check == true)
                {
                    doors_count++;
                    continue;
                }
                if (radiators_check == true)
                {
                    radiators_count++;
                    continue;
                }
                if (radiators_check == true)
                {
                    radiators_count++;
                    continue;
                }
            }
        }
        
        string[,] walls_array = new string[walls_count, 2];
        string[,] windows_array = new string[windows_count, 2];
        string[,] doors_array = new string[doors_count, 2];
        string[,] radiators_array = new string[radiators_count, 2];

        using (StreamReader sr = File.OpenText(filePath))
        {
            bool freq_check = false;
            bool walls_check = false;
            bool windows_check = false;
            bool doors_check = false;
            bool radiators_check = false;
            int walls_i = 0;
            int windows_i = 0;
            int freq_i = 0;
            int doors_i = 0;
            int radiators_i = 0;
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                if (line == "--walls--")
                {
                    walls_check = true;
                    windows_check = false;
                    doors_check = false;
                    freq_check = false;
                    radiators_check = false;
                    continue;
                }
                if (line == "--windows--")
                {
                    walls_check = false;
                    windows_check = true;
                    doors_check = false;
                    freq_check = false;
                    radiators_check = false;
                    continue;
                }
                if (line == "--doors--")
                {
                    walls_check = false;
                    windows_check = false;
                    doors_check = true;
                    freq_check = false;
                    radiators_check = false;
                    continue;
                }
                if (line == "--radiators--")
                {
                    walls_check = false;
                    windows_check = false;
                    doors_check = false;
                    freq_check = false;
                    radiators_check = true;
                    continue;
                }
                if (line == "--freq--")
                {
                    walls_check = false;
                    windows_check = false;
                    doors_check = false;
                    freq_check = true;
                    radiators_check = false;
                    continue;
                }
                if (line == "--end--")
                {
                    walls_check = false;
                    windows_check = false;
                    freq_check = false;
                    doors_check = false;
                    radiators_check = false;
                    break;
                }
                if (walls_check == true)
                {
                    walls_array[walls_i, 0] = line.Replace(".",",").Replace(".", ",").Split('|')[0];
                    walls_array[walls_i, 1] = line.Replace(".",",").Split('|')[1];
                    walls_i++;
                    continue;
                }
                if (freq_check == true)
                {
                    if (freq_i >= 21) continue;
                    freq_array[freq_i] = Convert.ToDouble(line.Replace(".",",").Replace(".",","));
                    freq_i++;
                    continue;
                }
                if (windows_check == true)
                {
                    windows_array[windows_i, 0] = line.Replace(".",",").Split('|')[0];
                    windows_array[windows_i, 1] = line.Replace(".",",").Split('|')[1];
                    windows_i++;
                    continue;
                }
                if (doors_check == true)
                {
                    doors_array[doors_i, 0] = line.Replace(".",",").Split('|')[0];
                    doors_array[doors_i, 1] = line.Replace(".",",").Split('|')[1];
                    doors_i++;
                    continue;
                }
                if (radiators_check == true)
                {
                    radiators_array[radiators_i, 0] = line.Replace(".",",").Split('|')[0];
                    radiators_array[radiators_i, 1] = line.Replace(".",",").Split('|')[1];
                    radiators_i++;
                    continue;
                }
            }
        }

        comboBox_FirstWallMaterial.Items.Clear();
        comboBox_FirstWallWindow.Items.Clear();
        comboBox_FirstWallDoor.Items.Clear();
        comboBox_FirstWallRadiator.Items.Clear();

        comboBox_SecondWallMaterial.Items.Clear();
        comboBox_SecondWallWindow.Items.Clear();
        comboBox_SecondWallDoor.Items.Clear();
        comboBox_SecondWallRadiator.Items.Clear();

        comboBox_ThirdWallMaterial.Items.Clear();
        comboBox_ThirdWallWindow.Items.Clear();
        comboBox_ThirdWallDoor.Items.Clear();
        comboBox_ThirdWallRadiator.Items.Clear();

        comboBox_FourthWallMaterial.Items.Clear();
        comboBox_FourthWallWindow.Items.Clear();
        comboBox_FourthWallDoor.Items.Clear();
        comboBox_FourthWallRadiator.Items.Clear();

        comboBox_FirstWallMaterial_par.Items.Clear();
        comboBox_FirstWallWindow_par.Items.Clear();
        comboBox_FirstWallDoor_par.Items.Clear();
        comboBox_FirstWallRadiator_par.Items.Clear();

        comboBox_SecondWallMaterial_par.Items.Clear();
        comboBox_SecondWallWindow_par.Items.Clear();
        comboBox_SecondWallDoor_par.Items.Clear();
        comboBox_SecondWallRadiator_par.Items.Clear();

        comboBox_ThirdWallMaterial_par.Items.Clear();
        comboBox_ThirdWallWindow_par.Items.Clear();
        comboBox_ThirdWallDoor_par.Items.Clear();
        comboBox_ThirdWallRadiator_par.Items.Clear();

        comboBox_FourthWallMaterial_par.Items.Clear();
        comboBox_FourthWallWindow_par.Items.Clear();
        comboBox_FourthWallDoor_par.Items.Clear();
        comboBox_FourthWallRadiator_par.Items.Clear();

        for (int i = 0; i < walls_count; i++)
        {
            comboBox_FirstWallMaterial.Items.Add(walls_array[i, 0]);
            comboBox_FirstWallMaterial_par.Items.Add(walls_array[i, 1]);
            comboBox_SecondWallMaterial.Items.Add(walls_array[i, 0]);
            comboBox_SecondWallMaterial_par.Items.Add(walls_array[i, 1]);
            comboBox_ThirdWallMaterial.Items.Add(walls_array[i, 0]);
            comboBox_ThirdWallMaterial_par.Items.Add(walls_array[i, 1]);
            comboBox_FourthWallMaterial.Items.Add(walls_array[i, 0]);
            comboBox_FourthWallMaterial_par.Items.Add(walls_array[i, 1]);
        }
        for (int i = 0; i < windows_count; i++)
        {
            comboBox_FirstWallWindow.Items.Add(windows_array[i, 0]);
            comboBox_FirstWallWindow_par.Items.Add(windows_array[i, 1]);
            comboBox_SecondWallWindow.Items.Add(windows_array[i, 0]);
            comboBox_SecondWallWindow_par.Items.Add(windows_array[i, 1]);
            comboBox_ThirdWallWindow.Items.Add(windows_array[i, 0]);
            comboBox_ThirdWallWindow_par.Items.Add(windows_array[i, 1]);
            comboBox_FourthWallWindow.Items.Add(windows_array[i, 0]);
            comboBox_FourthWallWindow_par.Items.Add(windows_array[i, 1]);
        }
        for (int i = 0; i < doors_count; i++)
        {
            comboBox_FirstWallDoor.Items.Add(doors_array[i, 0]);
            comboBox_FirstWallDoor_par.Items.Add(doors_array[i, 1]);
            comboBox_SecondWallDoor.Items.Add(doors_array[i, 0]);
            comboBox_SecondWallDoor_par.Items.Add(doors_array[i, 1]);
            comboBox_ThirdWallDoor.Items.Add(doors_array[i, 0]);
            comboBox_ThirdWallDoor_par.Items.Add(doors_array[i, 1]);
            comboBox_FourthWallDoor.Items.Add(doors_array[i, 0]);
            comboBox_FourthWallDoor_par.Items.Add(doors_array[i, 1]);
        }
        for (int i = 0; i < radiators_count; i++)
        {
            comboBox_FirstWallRadiator.Items.Add(radiators_array[i, 0]);
            comboBox_FirstWallRadiator_par.Items.Add(radiators_array[i, 1]);
            comboBox_SecondWallRadiator.Items.Add(radiators_array[i, 0]);
            comboBox_SecondWallRadiator_par.Items.Add(radiators_array[i, 1]);
            comboBox_ThirdWallRadiator.Items.Add(radiators_array[i, 0]);
            comboBox_ThirdWallRadiator_par.Items.Add(radiators_array[i, 1]);
            comboBox_FourthWallRadiator.Items.Add(radiators_array[i, 0]);
            comboBox_FourthWallRadiator_par.Items.Add(radiators_array[i, 1]);
        }
        comboBox_FirstWallMaterial.SelectedIndex = 0;
        comboBox_FirstWallWindow.SelectedIndex = 0;
        comboBox_FirstWallDoor.SelectedIndex = 0;
        comboBox_FirstWallRadiator.SelectedIndex = 0;
        comboBox_FirstWallMaterial_par.SelectedIndex = 0;
        comboBox_FirstWallWindow_par.SelectedIndex = 0;
        comboBox_FirstWallDoor_par.SelectedIndex = 0;
        comboBox_FirstWallRadiator_par.SelectedIndex = 0;

        comboBox_SecondWallMaterial.SelectedIndex = 0;
        comboBox_SecondWallWindow.SelectedIndex = 0;
        comboBox_SecondWallDoor.SelectedIndex = 0;
        comboBox_SecondWallRadiator.SelectedIndex = 0;
        comboBox_SecondWallMaterial_par.SelectedIndex = 0;
        comboBox_SecondWallWindow_par.SelectedIndex = 0;
        comboBox_SecondWallDoor_par.SelectedIndex = 0;
        comboBox_SecondWallRadiator_par.SelectedIndex = 0;

        comboBox_ThirdWallMaterial.SelectedIndex = 0;
        comboBox_ThirdWallWindow.SelectedIndex = 0;
        comboBox_ThirdWallDoor.SelectedIndex = 0;
        comboBox_ThirdWallRadiator.SelectedIndex = 0;
        comboBox_SecondWallMaterial_par.SelectedIndex = 0;
        comboBox_SecondWallWindow_par.SelectedIndex = 0;
        comboBox_SecondWallDoor_par.SelectedIndex = 0;
        comboBox_SecondWallRadiator_par.SelectedIndex = 0;

        comboBox_FourthWallMaterial.SelectedIndex = 0;
        comboBox_FourthWallWindow.SelectedIndex = 0;
        comboBox_FourthWallDoor.SelectedIndex = 0;
        comboBox_FourthWallRadiator.SelectedIndex = 0;
        comboBox_SecondWallMaterial_par.SelectedIndex = 0;
        comboBox_SecondWallWindow_par.SelectedIndex = 0;
        comboBox_SecondWallDoor_par.SelectedIndex = 0;
        comboBox_SecondWallRadiator_par.SelectedIndex = 0;
    }
    #endregion

    #region Автозаполнение длины и высоты стен комнаты
    private void FirstWallLenght_TextChanged(object sender, TextChangingEventArgs e)
    {
        ThirdWallLenght.Text = FirstWallLenght.Text;        
    }

    private void ThirdWallLenght_TextChanged(object sender, TextChangingEventArgs e)
    {
        FirstWallLenght.Text = ThirdWallLenght.Text;
    }

    private void SecondWallLenght_TextChanged(object sender, TextChangingEventArgs e)
    {
        FourthWallLenght.Text = SecondWallLenght.Text;
    }

    private void FourthWallLenght_TextChanged(object sender, TextChangingEventArgs e)
    {
       SecondWallLenght.Text = FourthWallLenght.Text;
    }

    private void FirstWallHeight_TextChanged(object sender, TextChangingEventArgs e)
    {
        SecondWallHeight.Text = FirstWallHeight.Text;
        ThirdWallHeight.Text = FirstWallHeight.Text;
        FourthWallHeight.Text = FirstWallHeight.Text;
    }

    private void SecondWallHeight_TextChanged(object sender, TextChangingEventArgs e)
    {
        FirstWallHeight.Text = SecondWallHeight.Text;
        ThirdWallHeight.Text = SecondWallHeight.Text;
        FourthWallHeight.Text = SecondWallHeight.Text;
    }

    private void ThirdWallHeight_TextChanged(object sender, TextChangingEventArgs e)
    {
        FirstWallHeight.Text = ThirdWallHeight.Text;
        SecondWallHeight.Text = ThirdWallHeight.Text;
        FourthWallHeight.Text = ThirdWallHeight.Text;
    }

    private void FourthWallHeight_TextChanged(object sender, TextChangingEventArgs e)
    {
        FirstWallHeight.Text = FourthWallHeight.Text;
        SecondWallHeight.Text = FourthWallHeight.Text;
        ThirdWallHeight.Text = FourthWallHeight.Text;
    }
    #endregion

    #region Кнопки меню
    private void TabButton1_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 0;

        
        Color color = Color.Parse("#6A6A6A");
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectFirstTab.Background = new SolidColorBrush(color);
    }

    private void TabButton2_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 1;

        
        
        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectSecondTab.Background = new SolidColorBrush(color);
    }

    private void TabButton3_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 2;

        
        
        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectThirdTab.Background = new SolidColorBrush(color);
    }

    private void TabButton4_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 3;

        
        
        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectFourthTab.Background = new SolidColorBrush(color);
    }
    
    private void TabButton5_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 4;
        
        (DataContext as MainWindowViewModel)?.WipeResult();
        (DataContext as MainWindowViewModel)?.GetFirstWallResult(
            FirstWallHeight.Text.Replace(".",","), FirstWallLenght.Text.Replace(".",","),
            FirstWallWindow_par1.Text.Replace(".",","), FirstWallWindow_par2.Text.Replace(".",","),
            FirstWallDoor_par1.Text.Replace(".",","), FirstWallDoor_par2.Text.Replace(".",","),
            FirstWallMaterial_par1.Text.Replace(".",","), FirstWallMaterial_par2.Text.Replace(".",","),
            FirstWallRadiator_par1.Text.Replace(".",","), FirstWallRadiator_par2.Text.Replace(".",","),
            comboBox_FirstSpeechLevel.SelectedIndex, Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")), freq_array);

        
        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectFifthTab.Background = new SolidColorBrush(color);
    }

    private void TabButton6_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 5;

        (DataContext as MainWindowViewModel)?.WipeResult();
        (DataContext as MainWindowViewModel)?.GetSecondWallResult(
            SecondWallHeight.Text.Replace(".",","), SecondWallLenght.Text.Replace(".",","),
            SecondWallWindow_par1.Text.Replace(".",","), SecondWallWindow_par2.Text.Replace(".",","),
            SecondWallDoor_par1.Text.Replace(".",","), SecondWallDoor_par2.Text.Replace(".",","),
            SecondWallMaterial_par1.Text.Replace(".",","), SecondWallMaterial_par2.Text.Replace(".",","),
            SecondWallRadiator_par1.Text.Replace(".",","), SecondWallRadiator_par2.Text.Replace(".",","),
            comboBox_SecondSpeechLevel.SelectedIndex, Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")), freq_array);

        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectSixthTab.Background = new SolidColorBrush(color);
    }
    
    private void TabButton7_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 6;

        (DataContext as MainWindowViewModel)?.WipeResult();
        (DataContext as MainWindowViewModel)?.GetThirdWallResult(
            ThirdWallHeight.Text.Replace(".",","), ThirdWallLenght.Text.Replace(".",","),
            ThirdWallWindow_par1.Text.Replace(".",","), ThirdWallWindow_par2.Text.Replace(".",","),
            ThirdWallDoor_par1.Text.Replace(".",","), ThirdWallDoor_par2.Text.Replace(".",","),
            ThirdWallMaterial_par1.Text.Replace(".",","), ThirdWallMaterial_par2.Text.Replace(".",","),
            ThirdWallRadiator_par1.Text.Replace(".",","), ThirdWallRadiator_par2.Text.Replace(".",","),
            comboBox_ThirdSpeechLevel.SelectedIndex, Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")), freq_array);

        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectSeventhTab.Background = new SolidColorBrush(color);
    }
    
    private void TabButton8_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 7;

        (DataContext as MainWindowViewModel)?.WipeResult();
        (DataContext as MainWindowViewModel)?.GetFourthWallResult(
            FourthWallHeight.Text.Replace(".",","), FourthWallLenght.Text.Replace(".",","),
            FourthWallWindow_par1.Text.Replace(".",","), FourthWallWindow_par2.Text.Replace(".",","),
            FourthWallDoor_par1.Text.Replace(".",","), FourthWallDoor_par2.Text.Replace(".",","),
            FourthWallMaterial_par1.Text.Replace(".",","), FourthWallMaterial_par2.Text.Replace(".",","),
            FourthWallRadiator_par1.Text.Replace(".",","), FourthWallRadiator_par2.Text.Replace(".",","),
            comboBox_FourthSpeechLevel.SelectedIndex, Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")), freq_array);

        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectEightTab.Background = new SolidColorBrush(color);
    }
    
    private void TabButton9_Click(object sender, RoutedEventArgs e)
    {
        
        tabControl.SelectedIndex = 8;
        
        ANSWER ans = new ANSWER();
        FirstWallOff1.IsVisible = true;
        FirstWallOn.IsVisible = false;

        SecondWallOff1.IsVisible = true;
        SecondWallOn.IsVisible = false;

        ThirdWallOff1.IsVisible = true;
        ThirdWallOn.IsVisible = false;

        FourthWallOff1.IsVisible = true;
        FourthWallOn.IsVisible = false;

        FirstRadiatorOn.IsVisible = false;
        FirstWindowOn.IsVisible = false;
        FirstDoorOn.IsVisible = false;

        SecondRadiatorOn.IsVisible = false;
        SecondWindowOn.IsVisible = false;
        SecondDoorOn.IsVisible = false;

        ThirdRadiatorOn.IsVisible = false;
        ThirdWindowOn.IsVisible = false;
        ThirdDoorOn.IsVisible = false;

        FourthRadiatorOn.IsVisible = false;
        FourthWindowOn.IsVisible = false;
        FourthDoorOn.IsVisible = false;

        FirstWallOff2.IsVisible = true;
        SecondWallOff2.IsVisible = true;
        ThirdWallOff2.IsVisible = true;
        FourthWallOff2.IsVisible = true;

        FirstWallOff3.IsVisible = true;
        SecondWallOff3.IsVisible = true;
        ThirdWallOff3.IsVisible = true;
        FourthWallOff3.IsVisible = true;

        FirstWallOff4.IsVisible = true;
        SecondWallOff4.IsVisible = true;
        ThirdWallOff4.IsVisible = true;
        FourthWallOff4.IsVisible = true;

        #region Просто стены
        try
        {            
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")), Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")),
            1, Convert.ToDouble(FirstWallMaterial_par1.Text.Replace(".",",")), comboBox_FirstSpeechLevel.SelectedIndex, Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")) != 0)
            {
                FirstWallOff1.IsVisible = false;
                FirstWallOn.IsVisible = true;
                FirstWallR.Text = "Интегральный индекс артикуляции речи для первой стены R = " + ans.R;
                FirstWallSR.Text = "Слоговая разборчивость для первой стены S(R) = " + ans.SR;
                FirstWallWS.Text = "Словесная разборчивость для первой стены W(S) = " + ans.WS;
                //FirstWallWR.Text = "Словесная разборчивость для первой стены W(R) = " + ans.WR;
            }
            else
            {
                FirstWallR.Text = "Интегральный индекс артикуляции речи для первой стены R = ";
                FirstWallSR.Text = "Слоговая разборчивость для первой стены S(R) = ";
                FirstWallWS.Text = "Словесная разборчивость для первой стены W(S) = ";
                //FirstWallWR.Text = "Словесная разборчивость для первой стены W(R) = ";
            }
        }
        catch
        {
            FirstWallR.Text = "Интегральный индекс артикуляции речи для первой стены R = ";
            FirstWallSR.Text = "Слоговая разборчивость для первой стены S(R) = ";
            FirstWallWS.Text = "Словесная разборчивость для первой стены W(S) = ";
            //FirstWallWR.Text = "Словесная разборчивость для первой стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")), Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")),
            1, Convert.ToDouble(SecondWallMaterial_par1.Text.Replace(".",",")), comboBox_SecondSpeechLevel.SelectedIndex, Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")) * Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")) * Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")) != 0)
            {
                SecondWallOff1.IsVisible = false;
                SecondWallOn.IsVisible = true;
                SecondWallR.Text = "Интегральный индекс артикуляции речи для второй стены R = " + ans.R;
                SecondWallSR.Text = "Слоговая разборчивость для второй стены S(R) = " + ans.SR;
                SecondWallWS.Text = "Словесная разборчивость для второй стены W(S) = " + ans.WS;
                //SecondWallWR.Text = "Словесная разборчивость для второй стены W(R) = " + ans.WR;
            }
            else
            {
                SecondWallR.Text = "Интегральный индекс артикуляции речи для второй стены R = ";
                SecondWallSR.Text = "Слоговая разборчивость для второй стены S(R) = ";
                SecondWallWS.Text = "Словесная разборчивость для второй стены W(S) = ";
                //SecondWallWR.Text = "Словесная разборчивость для второй стены W(R) = ";
            }
        }
        catch
        {
            SecondWallR.Text = "Интегральный индекс артикуляции речи для второй стены R = ";
            SecondWallSR.Text = "Слоговая разборчивость для второй стены S(R) = ";
            SecondWallWS.Text = "Словесная разборчивость для второй стены W(S) = ";
            //SecondWallWR.Text = "Словесная разборчивость для второй стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")), Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")),
            1, Convert.ToDouble(ThirdWallMaterial_par1.Text.Replace(".",",")), comboBox_ThirdSpeechLevel.SelectedIndex, Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")) != 0)
            {
                ThirdWallOff1.IsVisible = false;
                ThirdWallOn.IsVisible = true;
                ThirdWallR.Text = "Интегральный индекс артикуляции речи для третьей стены R = " + ans.R;
                ThirdWallSR.Text = "Слоговая разборчивость для третьей стены S(R) = " + ans.SR;
                ThirdWallWS.Text = "Словесная разборчивость для третьей стены W(S) = " + ans.WS;
                //ThirdWallWR.Text = "Словесная разборчивость для третьей стены W(R) = " + ans.WR;
            }
            else
            {
                ThirdWallR.Text = "Интегральный индекс артикуляции речи для третьей стены R = ";
                ThirdWallSR.Text = "Слоговая разборчивость для третьей стены S(R) = ";
                ThirdWallWS.Text = "Словесная разборчивость для третьей стены W(S) = ";
                //ThirdWallWR.Text = "Словесная разборчивость для третьей стены W(R) = ";
            }
        }
        catch
        {
            ThirdWallR.Text = "Интегральный индекс артикуляции речи для третьей стены R = ";
            ThirdWallSR.Text = "Слоговая разборчивость для третьей стены S(R) = ";
            ThirdWallWS.Text = "Словесная разборчивость для третьей стены W(S) = ";
            //ThirdWallWR.Text = "Словесная разборчивость для третьей стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FourthWallHeight.Text.Replace(".",",").Replace(".",",")), Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")),
            1, Convert.ToDouble(FourthWallMaterial_par1.Text.Replace(".",",")), comboBox_FourthSpeechLevel.SelectedIndex, Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")) != 0)
            {
                FourthWallOff1.IsVisible = false;
                FourthWallOn.IsVisible = true;
                FourthWallR.Text = "Интегральный индекс артикуляции речи для четвертой стены R = " + ans.R;
                FourthWallSR.Text = "Слоговая разборчивость для четвертой стены S(R) = " + ans.SR;
                FourthWallWS.Text = "Словесная разборчивость для четвертой стены W(S) = " + ans.WS;
               // FourthWallWR.Text = "Словесная разборчивость для четвертой стены W(R) = " + ans.WR;
            }
            else
            {
                FourthWallR.Text = "Интегральный индекс артикуляции речи для четвертой стены R = ";
                FourthWallSR.Text = "Слоговая разборчивость для четвертой стены S(R) = ";
                FourthWallWS.Text = "Словесная разборчивость для четвертой стены W(S) = ";
                //FourthWallWR.Text = "Словесная разборчивость для четвертой стены W(R) = ";
            }
        }
        catch
        {
            FourthWallR.Text = "Интегральный индекс артикуляции речи для четвертой стены R = ";
            FourthWallSR.Text = "Слоговая разборчивость для четвертой стены S(R) = ";
            FourthWallWS.Text = "Словесная разборчивость для четвертой стены W(S) = ";
           // FourthWallWR.Text = "Словесная разборчивость для четвертой стены W(R) = ";
        }
        #endregion

        #region Батареи

        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")), Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(FirstWallRadiator_par2.Text.Replace(".",",")), Convert.ToDouble(FirstWallRadiator_par1.Text.Replace(".",",")), comboBox_FirstSpeechLevel.SelectedIndex, Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")) * Convert.ToDouble(FirstWallRadiator_par1.Text.Replace(".",",")) != 0)
            {
                FirstRadiatorOn.IsVisible = true;
                FirstRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи первой стены R = " + ans.R;
                FirstRadiatorSR.Text = "Слоговая разборчивость для батареи первой стены S(R) = " + ans.SR;
                FirstRadiatorWS.Text = "Словесная разборчивость для батареи первой стены W(S) = " + ans.WS;
                //FirstRadiatorWR.Text = "Словесная разборчивость для батареи первой стены W(R) = " + ans.WR;
            }
            else
            {
                FirstRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи первой стены R = ";
                FirstRadiatorSR.Text = "Слоговая разборчивость для батареи первой стены S(R) = ";
                FirstRadiatorWS.Text = "Словесная разборчивость для батареи первой стены W(S) = ";
                //FirstRadiatorWR.Text = "Словесная разборчивость для батареи первой стены W(R) = ";
            }
        }
        catch
        {
            FirstRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи первой стены R = ";
            FirstRadiatorSR.Text = "Слоговая разборчивость для батареи первой стены S(R) = ";
            FirstRadiatorWS.Text = "Словесная разборчивость для батареи первой стены W(S) = ";
            //FirstRadiatorWR.Text = "Словесная разборчивость для батареи первой стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")), Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(SecondWallRadiator_par2.Text.Replace(".",",")), Convert.ToDouble(SecondWallRadiator_par1.Text.Replace(".",",")), comboBox_SecondSpeechLevel.SelectedIndex, Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")) * Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")) * Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")) * Convert.ToDouble(SecondWallRadiator_par1.Text.Replace(".",",")) != 0)
            {
                SecondRadiatorOn.IsVisible = true;
                SecondRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи второй стены R = " + ans.R;
                SecondRadiatorSR.Text = "Слоговая разборчивость для батареи второй стены S(R) = " + ans.SR;
                SecondRadiatorWS.Text = "Словесная разборчивость для батареи второй стены W(S) = " + ans.WS;
                //SecondRadiatorWR.Text = "Словесная разборчивость для батареи второй стены W(R) = " + ans.WR;
            }
            else
            {
                SecondRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи второй стены R = ";
                SecondRadiatorSR.Text = "Слоговая разборчивость для батареи второй стены S(R) = ";
                SecondRadiatorWS.Text = "Словесная разборчивость для батареи второй стены W(S) = ";
                //SecondRadiatorWR.Text = "Словесная разборчивость для батареи второй стены W(R) = ";
            }
        }
        catch
        {
            SecondRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи второй стены R = ";
            SecondRadiatorSR.Text = "Слоговая разборчивость для батареи второй стены S(R) = ";
            SecondRadiatorWS.Text = "Словесная разборчивость для батареи второй стены W(S) = ";
           // SecondRadiatorWR.Text = "Словесная разборчивость для батареи второй стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")), Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(ThirdWallRadiator_par2.Text.Replace(".",",")), Convert.ToDouble(ThirdWallRadiator_par1.Text.Replace(".",",")), comboBox_ThirdSpeechLevel.SelectedIndex, Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallRadiator_par1.Text.Replace(".",",")) != 0)
            {
                ThirdRadiatorOn.IsVisible = true;
                ThirdRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи третьей стены R = " + ans.R;
                ThirdRadiatorSR.Text = "Слоговая разборчивость для батареи третьей стены S(R) = " + ans.SR;
                ThirdRadiatorWS.Text = "Словесная разборчивость для батареи третьей стены W(S) = " + ans.WS;
                //ThirdRadiatorWR.Text = "Словесная разборчивость для батареи третьей стены W(R) = " + ans.WR;
            }
            else
            {
                ThirdRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи третьей стены R = ";
                ThirdRadiatorSR.Text = "Слоговая разборчивость для батареи третьей стены S(R) = ";
                ThirdRadiatorWS.Text = "Словесная разборчивость для батареи третьей стены W(S) = ";
                //ThirdRadiatorWR.Text = "Словесная разборчивость для батареи третьей стены W(R) = ";
            }
        }
        catch
        {
            ThirdRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи третьей стены R = ";
            ThirdRadiatorSR.Text = "Слоговая разборчивость для батареи третьей стены S(R) = ";
            ThirdRadiatorWS.Text = "Словесная разборчивость для батареи третьей стены W(S) = ";
           // ThirdRadiatorWR.Text = "Словесная разборчивость для батареи третьей стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")), Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(FourthWallRadiator_par2.Text.Replace(".",",")), Convert.ToDouble(FourthWallRadiator_par1.Text.Replace(".",",")), comboBox_FourthSpeechLevel.SelectedIndex, Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")) * Convert.ToDouble(FourthWallRadiator_par1.Text.Replace(".",",")) != 0)
            {
                FourthRadiatorOn.IsVisible = true;
                FourthRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи четвертой стены R = " + ans.R;
                FourthRadiatorSR.Text = "Слоговая разборчивость для батареи четвертой стены S(R) = " + ans.SR;
                FourthRadiatorWS.Text = "Словесная разборчивость для батареи четвертой стены W(S) = " + ans.WS;
                //FourthRadiatorWR.Text = "Словесная разборчивость для батареи четвертой стены W(R) = " + ans.WR;
            }
            else
            {
                FourthRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи четвертой стены R = ";
                FourthRadiatorSR.Text = "Слоговая разборчивость для батареи четвертой стены S(R) = ";
                FourthRadiatorWS.Text = "Словесная разборчивость для батареи четвертой стены W(S) = ";
                //FourthRadiatorWR.Text = "Словесная разборчивость для батареи четвертой стены W(R) = ";
            }
        }
        catch
        {
            FourthRadiatorR.Text = "Интегральный индекс артикуляции речи для батареи четвертой стены R = ";
            FourthRadiatorSR.Text = "Слоговая разборчивость для батареи четвертой стены S(R) = ";
            FourthRadiatorWS.Text = "Словесная разборчивость для батареи четвертой стены W(S) = ";
           // FourthRadiatorWR.Text = "Словесная разборчивость для батареи четвертой стены W(R) = ";
        }
        #endregion

        #region Окна
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")), Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(FirstWallWindow_par2.Text.Replace(".",",")), Convert.ToDouble(FirstWallWindow_par1.Text.Replace(".",",")), comboBox_FirstSpeechLevel.SelectedIndex, Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")) * Convert.ToDouble(FirstWallWindow_par1.Text.Replace(".",",")) != 0)
            {
                FirstWallOff3.IsVisible = false;
                FirstWindowOn.IsVisible = true;
                FirstWindowR.Text = "Интегральный индекс артикуляции речи для окна первой стены R = " + ans.R;
                FirstWindowSR.Text = "Слоговая разборчивость для окна первой стены S(R) = " + ans.SR;
                FirstWindowWS.Text = "Словесная разборчивость для окна первой стены W(S) = " + ans.WS;
                //FirstWindowWR.Text = "Словесная разборчивость для окна первой стены W(R) = " + ans.WR;
            }
            else
            {
                FirstWindowR.Text = "Интегральный индекс артикуляции речи для окна первой стены R = ";
                FirstWindowSR.Text = "Слоговая разборчивость для окна первой стены S(R) = ";
                FirstWindowWS.Text = "Словесная разборчивость для окна первой стены W(S) = ";
                //FirstWindowWR.Text = "Словесная разборчивость для окна первой стены W(R) = ";
            }
        }
        catch
        {
            FirstWindowR.Text = "Интегральный индекс артикуляции речи для окна первой стены R = ";
            FirstWindowSR.Text = "Слоговая разборчивость для окна первой стены S(R) = ";
            FirstWindowWS.Text = "Словесная разборчивость для окна первой стены W(S) = ";
            //FirstWindowWR.Text = "Словесная разборчивость для окна первой стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")), Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(SecondWallWindow_par2.Text.Replace(".",",")), Convert.ToDouble(SecondWallWindow_par1.Text.Replace(".",",")), comboBox_SecondSpeechLevel.SelectedIndex, Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")) * Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")) * Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")) * Convert.ToDouble(SecondWallWindow_par1.Text.Replace(".",",")) != 0)
            {
                SecondWallOff3.IsVisible = false;
                SecondWindowOn.IsVisible = true;
                SecondWindowR.Text = "Интегральный индекс артикуляции речи для окна второй стены R = " + ans.R;
                SecondWindowSR.Text = "Слоговая разборчивость для окна второй стены S(R) = " + ans.SR;
                SecondWindowWS.Text = "Словесная разборчивость для окна второй стены W(S) = " + ans.WS;
                //SecondWindowWR.Text = "Словесная разборчивость для окна второй стены W(R) = " + ans.WR;
            }
            else
            {
                SecondWindowR.Text = "Интегральный индекс артикуляции речи для окна второй стены R = ";
                SecondWindowSR.Text = "Слоговая разборчивость для окна второй стены S(R) = ";
                SecondWindowWS.Text = "Словесная разборчивость для окна второй стены W(S) = ";
                //SecondWindowWR.Text = "Словесная разборчивость для окна второй стены W(R) = ";
            }
        }
        catch
        {
            SecondWindowR.Text = "Интегральный индекс артикуляции речи для окна второй стены R = ";
            SecondWindowSR.Text = "Слоговая разборчивость для окна второй стены S(R) = ";
            SecondWindowWS.Text = "Словесная разборчивость для окна второй стены W(S) = ";
           // SecondWindowWR.Text = "Словесная разборчивость для окна второй стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")), Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(ThirdWallWindow_par2.Text.Replace(".",",")), Convert.ToDouble(ThirdWallWindow_par1.Text.Replace(".",",")), comboBox_ThirdSpeechLevel.SelectedIndex, Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallWindow_par1.Text.Replace(".",",")) != 0)
            {
                ThirdWallOff3.IsVisible = false;
                ThirdWindowOn.IsVisible = true;
                ThirdWindowR.Text = "Интегральный индекс артикуляции речи для окна третьей стены R = " + ans.R;
                ThirdWindowSR.Text = "Слоговая разборчивость для окна третьей стены S(R) = " + ans.SR;
                ThirdWindowWS.Text = "Словесная разборчивость для окна третьей стены W(S) = " + ans.WS;
                //ThirdWindowWR.Text = "Словесная разборчивость для окна третьей стены W(R) = " + ans.WR;
            }
            else
            {
                ThirdWindowR.Text = "Интегральный индекс артикуляции речи для окна третьей стены R = ";
                ThirdWindowSR.Text = "Слоговая разборчивость для окна третьей стены S(R) = ";
                ThirdWindowWS.Text = "Словесная разборчивость для окна третьей стены W(S) = ";
                //ThirdWindowWR.Text = "Словесная разборчивость для окна третьей стены W(R) = ";
            }
        }
        catch
        {
            ThirdWindowR.Text = "Интегральный индекс артикуляции речи для окна третьей стены R = ";
            ThirdWindowSR.Text = "Слоговая разборчивость для окна третьей стены S(R) = ";
            ThirdWindowWS.Text = "Словесная разборчивость для окна третьей стены W(S) = ";
           // ThirdWindowWR.Text = "Словесная разборчивость для окна третьей стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")), Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(FourthWallWindow_par2.Text.Replace(".",",")), Convert.ToDouble(FourthWallWindow_par1.Text.Replace(".",",")), comboBox_FourthSpeechLevel.SelectedIndex, Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")) * Convert.ToDouble(FourthWallWindow_par1.Text.Replace(".",",")) != 0)
            {
                FourthWallOff3.IsVisible = false;
                FourthWindowOn.IsVisible = true;
                FourthWindowR.Text = "Интегральный индекс артикуляции речи для окна четвертой стены R = " + ans.R;
                FourthWindowSR.Text = "Слоговая разборчивость для окна четвертой стены S(R) = " + ans.SR;
                FourthWindowWS.Text = "Словесная разборчивость для окна четвертой стены W(S) = " + ans.WS;
                //FourthWindowWR.Text = "Словесная разборчивость для окна четвертой стены W(R) = " + ans.WR;
            }
            else
            {
                FourthWindowR.Text = "Интегральный индекс артикуляции речи для окна четвертой стены R = ";
                FourthWindowSR.Text = "Слоговая разборчивость для окна четвертой стены S(R) = ";
                FourthWindowWS.Text = "Словесная разборчивость для окна четвертой стены W(S) = ";
                //FourthWindowWR.Text = "Словесная разборчивость для окна четвертой стены W(R) = ";
            }
        }
        catch
        {
            FourthWindowR.Text = "Интегральный индекс артикуляции речи для окна четвертой стены R = ";
            FourthWindowSR.Text = "Слоговая разборчивость для окна четвертой стены S(R) = ";
            FourthWindowWS.Text = "Словесная разборчивость для окна четвертой стены W(S) = ";
            //FourthWindowWR.Text = "Словесная разборчивость для окна четвертой стены W(R) = ";
        }
        #endregion

        #region Двери
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")), Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(FirstWallDoor_par2.Text.Replace(".",",")), Convert.ToDouble(FirstWallDoor_par1.Text.Replace(".",",")), comboBox_FirstSpeechLevel.SelectedIndex, Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FirstWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FirstWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FirstWallVolume.Text.Replace(".",",")) * Convert.ToDouble(FirstWallDoor_par1.Text.Replace(".",",")) != 0)
            {

                FirstWallOff4.IsVisible = false;
                FirstDoorOn.IsVisible = true;
                FirstDoorR.Text = "Интегральный индекс артикуляции речи для двери первой стены R = " + ans.R;
                FirstDoorSR.Text = "Слоговая разборчивость для двери первой стены S(R) = " + ans.SR;
                FirstDoorWS.Text = "Словесная разборчивость для двери первой стены W(S) = " + ans.WS;
                //FirstDoorWR.Text = "Словесная разборчивость для двери первой стены W(R) = " + ans.WR;
            }
            else
            {
                FirstDoorR.Text = "Интегральный индекс артикуляции речи для двери первой стены R = ";
                FirstDoorSR.Text = "Слоговая разборчивость для двери первой стены S(R) = ";
                FirstDoorWS.Text = "Словесная разборчивость для двери первой стены W(S) = ";
                //FirstDoorWR.Text = "Словесная разборчивость для двери первой стены W(R) = ";
            }
        }
        catch
        {
            FirstDoorR.Text = "Интегральный индекс артикуляции речи для двери первой стены R = ";
            FirstDoorSR.Text = "Слоговая разборчивость для двери первой стены S(R) = ";
            FirstDoorWS.Text = "Словесная разборчивость для двери первой стены W(S) = ";
            //FirstDoorWR.Text = "Словесная разборчивость для двери первой стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")), Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(SecondWallDoor_par2.Text.Replace(".",",")), Convert.ToDouble(SecondWallDoor_par1.Text.Replace(".",",")), comboBox_SecondSpeechLevel.SelectedIndex, Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(SecondWallHeight.Text.Replace(".",",")) * Convert.ToDouble(SecondWallLenght.Text.Replace(".",",")) * Convert.ToDouble(SecondWallVolume.Text.Replace(".",",")) * Convert.ToDouble(SecondWallDoor_par1.Text.Replace(".",",")) != 0)
            {
                SecondDoorOn.IsVisible = true;
                SecondWallOff4.IsVisible = false;
                SecondDoorR.Text = "Интегральный индекс артикуляции речи для двери второй стены R = " + ans.R;
                SecondDoorSR.Text = "Слоговая разборчивость для двери второй стены S(R) = " + ans.SR;
                SecondDoorWS.Text = "Словесная разборчивость для двери второй стены W(S) = " + ans.WS;
                //SecondDoorWR.Text = "Словесная разборчивость для двери второй стены W(R) = " + ans.WR;
            }
            else
            {
                SecondDoorR.Text = "Интегральный индекс артикуляции речи для двери второй стены R = ";
                SecondDoorSR.Text = "Слоговая разборчивость для двери второй стены S(R) = ";
                SecondDoorWS.Text = "Словесная разборчивость для двери второй стены W(S) = ";
                //SecondDoorWR.Text = "Словесная разборчивость для двери второй стены W(R) = ";
            }
        }
        catch
        {
            SecondDoorR.Text = "Интегральный индекс артикуляции речи для двери второй стены R = ";
            SecondDoorSR.Text = "Слоговая разборчивость для двери второй стены S(R) = ";
            SecondDoorWS.Text = "Словесная разборчивость для двери второй стены W(S) = ";
           // SecondDoorWR.Text = "Словесная разборчивость для двери второй стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")), Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(ThirdWallDoor_par2.Text.Replace(".",",")), Convert.ToDouble(ThirdWallDoor_par1.Text.Replace(".",",")), comboBox_ThirdSpeechLevel.SelectedIndex, Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(ThirdWallHeight.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallLenght.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallVolume.Text.Replace(".",",")) * Convert.ToDouble(ThirdWallDoor_par1.Text.Replace(".",",")) != 0)
            {
                ThirdDoorOn.IsVisible = true;
                ThirdWallOff4.IsVisible = false;
                ThirdDoorR.Text = "Интегральный индекс артикуляции речи для двери третьей стены R = " + ans.R;
                ThirdDoorSR.Text = "Слоговая разборчивость для двери третьей стены S(R) = " + ans.SR;
                ThirdDoorWS.Text = "Словесная разборчивость для двери третьей стены W(S) = " + ans.WS;
                //ThirdDoorWR.Text = "Словесная разборчивость для двери третьей стены W(R) = " + ans.WR;
            }
            else
            {
                ThirdDoorR.Text = "Интегральный индекс артикуляции речи для двери третьей стены R = ";
                ThirdDoorSR.Text = "Слоговая разборчивость для двери третьей стены S(R) = ";
                ThirdDoorWS.Text = "Словесная разборчивость для двери третьей стены W(S) = ";
               // ThirdDoorWR.Text = "Словесная разборчивость для двери третьей стены W(R) = ";
            }
        }
        catch
        {
            ThirdDoorR.Text = "Интегральный индекс артикуляции речи для двери третьей стены R = ";
            ThirdDoorSR.Text = "Слоговая разборчивость для двери третьей стены S(R) = ";
            ThirdDoorWS.Text = "Словесная разборчивость для двери третьей стены W(S) = ";
           // ThirdDoorWR.Text = "Словесная разборчивость для двери третьей стены W(R) = ";
        }
        try
        {
            ans = (DataContext as MainWindowViewModel)?.Result(Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")), Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")),
            Convert.ToDouble(FourthWallDoor_par2.Text.Replace(".",",")), Convert.ToDouble(FourthWallDoor_par1.Text.Replace(".",",")), comboBox_FourthSpeechLevel.SelectedIndex, Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")));
            if (Convert.ToDouble(FourthWallHeight.Text.Replace(".",",")) * Convert.ToDouble(FourthWallLenght.Text.Replace(".",",")) * Convert.ToDouble(FourthWallVolume.Text.Replace(".",",")) * Convert.ToDouble(FourthWallDoor_par1.Text.Replace(".",",")) != 0)
            {
                FourthWallOff4.IsVisible = false;
                FourthDoorOn.IsVisible = true;
                FourthDoorR.Text = "Интегральный индекс артикуляции речи для двери четвертой стены R = " + ans.R;
                FourthDoorSR.Text = "Слоговая разборчивость для двери четвертой стены S(R) = " + ans.SR;
                FourthDoorWS.Text = "Словесная разборчивость для двери четвертой стены W(S) = " + ans.WS;
                //FourthDoorWR.Text = "Словесная разборчивость для двери четвертой стены W(R) = " + ans.WR;
            }
            else
            {
                FourthDoorR.Text = "Интегральный индекс артикуляции речи для двери четвертой стены R = ";
                FourthDoorSR.Text = "Слоговая разборчивость для двери четвертой стены S(R) = ";
                FourthDoorWS.Text = "Словесная разборчивость для двери четвертой стены W(S) = ";
                //FourthDoorWR.Text = "Словесная разборчивость для двери четвертой стены W(R) = ";
            }
        }
        catch
        {
            FourthDoorR.Text = "Интегральный индекс артикуляции речи для двери четвертой стены R = ";
            FourthDoorSR.Text = "Слоговая разборчивость для двери четвертой стены S(R) = ";
            FourthDoorWS.Text = "Словесная разборчивость для двери четвертой стены W(S) = ";
            //FourthDoorWR.Text = "Словесная разборчивость для двери четвертой стены W(R) = ";
        }
        #endregion
        
        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectHelpTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectNinthTab.Background = new SolidColorBrush(color);
    }
    
    private void TabButton10_Click(object sender, RoutedEventArgs e)
    {
        tabControl.SelectedIndex = 9;

        
        
        Color color = Color.Parse("#6A6A6A");
        SelectFirstTab.Background = new SolidColorBrush(color);
        SelectSecondTab.Background = new SolidColorBrush(color);
        SelectThirdTab.Background = new SolidColorBrush(color);
        SelectFourthTab.Background = new SolidColorBrush(color);
        SelectFifthTab.Background = new SolidColorBrush(color);
        SelectSixthTab.Background = new SolidColorBrush(color);
        SelectSeventhTab.Background = new SolidColorBrush(color);
        SelectEightTab.Background = new SolidColorBrush(color);
        SelectNinthTab.Background = new SolidColorBrush(color);
        color = Color.Parse("#4CAF50");
        SelectHelpTab.Background = new SolidColorBrush(color);
    }
    #endregion

}
