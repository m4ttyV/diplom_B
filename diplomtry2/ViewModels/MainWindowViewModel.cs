using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Authentication.ExtendedProtection;

namespace diplomtry2.ViewModels;

public class TableData
{
    public string Octave_Number { get; set; }
    public string fn { get; set; }
    public string fv { get; set; }
    public string fi { get; set; }
    public string Kf { get; set; }
    public string delAi { get; set; }
    public string Ls { get; set; }
    public string Lw { get; set; }
    public string qi { get; set; }
    public string Qi { get; set; }
    public string ki { get; set; }
    public string pi { get; set; }
    public string Ri { get; set; }

}

public class Speech_Levels
{
    public string type { get; set; }
    public double AverageFrequency250 { get; set; }
    public double AverageFrequency500 { get; set; }
    public double AverageFrequency1000 { get; set; }
    public double AverageFrequency2000 { get; set; }
    public double AverageFrequency4000 { get; set; }
    public double AverageFrequency6000 { get; set; }
    public double Sum_Levels { get; set; }
}

public class ANSWER
{
    public string R { get; set; }
    public string SR { get; set; }
    public string WS { get; set; }
    public string WR { get; set; }
}

public class Pokrovsiy
{
    public double fsr(double fv, double fl)
    {
        return Math.Sqrt(fv * fl);
    }

    public double delAi(double Lci, double Ai)
    {
        return Lci - Ai;
    }

    public double kf(double f)
    {
        double ans = 0;
        if ((f > 100) && (f < 400))
            ans = 2.57 * Math.Pow(10, -8) * Math.Pow(f, 2.4);
        else if ((f >= 400) && (f <= 10000))
            ans = 1 - 1.074 * Math.Exp(-0.0001 * Math.Pow(f, 1.18));
        return ans;
    }

    public double Ri(double pi, double ki)
    {
        double ans = pi*ki;
        return pi * ki;
    }

    public double ki(double fn, double fv)
    {
        return Math.Abs(kf(fv) - kf(fn));
    }

    public double delAf(double f)
    {
        if (f <= 1000) return 200.0 / Math.Pow(f, 0.43) - 0.37;
        else return 1.37 + 1000.0 / Math.Pow(f, 0.69);
    }

    public double pi(double Qi)
    {
        if (Qi <= 0) return (0.78 + 5.46 * Math.Exp(-4.3 * 0.001 * Math.Pow(27.3 - Math.Abs(Qi), 2))) / (1.0 + Math.Pow(10, 0.1 * Math.Abs(Qi)));
        else return 1 - (0.78 + 5.46 * Math.Exp(-4.3 * 0.001 * Math.Pow(27.3 - Math.Abs(Qi), 2))) / (1.0 + Math.Pow(10, 0.1 * Math.Abs(Qi)));
    }

    public double Qi(double qi, double delAi)
    {
        return qi - delAi;
    }

    public double qi(double Lci, double Lwc)
    {
        return Lci - Lwc;
    }

    public double S(double R)
    {
        if (R < 0.15) return 4 * Math.Pow(R, 1.43);
        else if (R > 0.7) return 1.1 * (1 - 1.17 * Math.E * (2.9 * R));
        else return 1.1 * (1 - 9.1 * Math.Exp(-6.9 * R));
    }

    public double W(double R)
    {
        if (R < 0.15) return 1.54 * Math.Pow(R, 0.25) * (1 - Math.E * (-11 * R));
        else return 1 - Math.E * ((-11 * R) / (1 + 0.7 * R));
    }
    public double WS(double S)
    {
       return 1.05*(1-Math.Exp(-6.15*S/(1+S)));
    }

    public double L(double L0, double Sp, double R, double x) //x - поправка в дБ (-6 или 6)
    {
        double a = Math.Log10(Sp);
        double ans = L0 + 10 * a - R - x;
        return ans;
    }
    
    public double Sp(double a, double b) 
    {
        return a*b;
    }
}

public class MainWindowViewModel : ViewModelBase
{

    public ObservableCollection<TableData> FirstWallOutput1 { get; set; }
    public ObservableCollection<TableData> FirstWallOutput2 { get; set; }
    public ObservableCollection<TableData> FirstWallOutput3 { get; set; }
    public ObservableCollection<TableData> FirstWallOutput4 { get; set; }
    public ObservableCollection<TableData> SecondWallOutput1 { get; set; }
    public ObservableCollection<TableData> SecondWallOutput2 { get; set; }
    public ObservableCollection<TableData> SecondWallOutput3 { get; set; }
    public ObservableCollection<TableData> SecondWallOutput4 { get; set; }
    public ObservableCollection<TableData> ThirdWallOutput1 { get; set; }
    public ObservableCollection<TableData> ThirdWallOutput2 { get; set; }
    public ObservableCollection<TableData> ThirdWallOutput3 { get; set; }
    public ObservableCollection<TableData> ThirdWallOutput4 { get; set; }
    public ObservableCollection<TableData> FourthWallOutput1 { get; set; }
    public ObservableCollection<TableData> FourthWallOutput2 { get; set; }
    public ObservableCollection<TableData> FourthWallOutput3 { get; set; }
    public ObservableCollection<TableData> FourthWallOutput4 { get; set; }

    public MainWindowViewModel()
    {
        FirstWallOutput1 = new ObservableCollection<TableData> { };
        FirstWallOutput2 = new ObservableCollection<TableData> { };
        FirstWallOutput3 = new ObservableCollection<TableData> { };
        FirstWallOutput4 = new ObservableCollection<TableData> { };
        SecondWallOutput1 = new ObservableCollection<TableData> { };
        SecondWallOutput2 = new ObservableCollection<TableData> { };
        SecondWallOutput3 = new ObservableCollection<TableData> { };
        SecondWallOutput4 = new ObservableCollection<TableData> { };
        ThirdWallOutput1 = new ObservableCollection<TableData> { };
        ThirdWallOutput2 = new ObservableCollection<TableData> { };
        ThirdWallOutput3 = new ObservableCollection<TableData> { };
        ThirdWallOutput4 = new ObservableCollection<TableData> { };
        FourthWallOutput1 = new ObservableCollection<TableData> { };
        FourthWallOutput2 = new ObservableCollection<TableData> { };
        FourthWallOutput3 = new ObservableCollection<TableData> { };
        FourthWallOutput4 = new ObservableCollection<TableData> { };
       
    }
    public void WipeResult()
    {
        FirstWallOutput1.Clear();
        FirstWallOutput2.Clear();
        FirstWallOutput3.Clear();
        FirstWallOutput4.Clear();
        SecondWallOutput1.Clear();
        SecondWallOutput2.Clear();
        SecondWallOutput3.Clear();
        SecondWallOutput4.Clear();
        ThirdWallOutput1.Clear();
        ThirdWallOutput2.Clear();
        ThirdWallOutput3.Clear();
        ThirdWallOutput4.Clear();
        FourthWallOutput1.Clear();
        FourthWallOutput2.Clear();
        FourthWallOutput3.Clear();
        FourthWallOutput4.Clear();
    }
    
    void WallResult(double WallHeight, double WallLenght,
        double Sp, double R,
        int speechLevel, double VolLoudness, ObservableCollection<TableData> WallOutput, double[] freq_array)
    {
        Sp = WallHeight * WallLenght*Sp;
        List<Speech_Levels> speech_Levels = new List<Speech_Levels>
        {
            new Speech_Levels { type = "речь", AverageFrequency250 = 67.9, AverageFrequency500 = 66.9, AverageFrequency1000 = 61.5, AverageFrequency2000 = 57, AverageFrequency4000 = 53, AverageFrequency6000 = 48.5, Sum_Levels = 1},
            new Speech_Levels { type = "ПС-20", AverageFrequency250 = 31, AverageFrequency500 = 24, AverageFrequency1000 = 20, AverageFrequency2000 = 17, AverageFrequency4000 = 14, AverageFrequency6000 = 13, Sum_Levels = 32.3},
            new Speech_Levels { type = "ПС-25", AverageFrequency250 = 35, AverageFrequency500 = 29, AverageFrequency1000 = 25, AverageFrequency2000 = 22, AverageFrequency4000 = 20, AverageFrequency6000 = 18, Sum_Levels = 36.6},
            new Speech_Levels { type = "ПС-30", AverageFrequency250 = 40, AverageFrequency500 = 34, AverageFrequency1000 = 30, AverageFrequency2000 = 27, AverageFrequency4000 = 25, AverageFrequency6000 = 23, Sum_Levels = 41.6},
            new Speech_Levels { type = "ПС-35", AverageFrequency250 = 45, AverageFrequency500 = 39, AverageFrequency1000 = 35, AverageFrequency2000 = 32, AverageFrequency4000 = 30, AverageFrequency6000 = 28, Sum_Levels = 47},
            new Speech_Levels { type = "ПС-40", AverageFrequency250 = 49, AverageFrequency500 = 44, AverageFrequency1000 = 40, AverageFrequency2000 = 37, AverageFrequency4000 = 35, AverageFrequency6000 = 33, Sum_Levels = 51},
            new Speech_Levels { type = "ПС-45", AverageFrequency250 = 54, AverageFrequency500 = 49, AverageFrequency1000 = 45, AverageFrequency2000 = 42, AverageFrequency4000 = 40, AverageFrequency6000 = 38, Sum_Levels = 60},
            new Speech_Levels { type = "ПС-50", AverageFrequency250 = 59, AverageFrequency500 = 54, AverageFrequency1000 = 50, AverageFrequency2000 = 47, AverageFrequency4000 = 44, AverageFrequency6000 = 43, Sum_Levels = 61},
            new Speech_Levels { type = "ПС-55", AverageFrequency250 = 63, AverageFrequency500 = 59, AverageFrequency1000 = 55, AverageFrequency2000 = 52, AverageFrequency4000 = 50, AverageFrequency6000 = 49, Sum_Levels = 65},
        };        

        Pokrovsiy pokrovsiy = new Pokrovsiy();

        double Ls = pokrovsiy.L(VolLoudness, Sp, R, 6);

        Sp = pokrovsiy.Sp(WallHeight, WallLenght);

        double[] L0 = new double[]
        {
            speech_Levels[speechLevel].AverageFrequency250,
            speech_Levels[speechLevel].AverageFrequency500,
            speech_Levels[speechLevel].AverageFrequency500,
            speech_Levels[speechLevel].AverageFrequency500,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency4000,
            speech_Levels[speechLevel].AverageFrequency4000,
            speech_Levels[speechLevel].AverageFrequency6000,
            speech_Levels[speechLevel].AverageFrequency6000
        };

        double[] fi = new double[]
        {
            pokrovsiy.fsr(freq_array[0],freq_array[1]),
            pokrovsiy.fsr(freq_array[1],freq_array[2]),
            pokrovsiy.fsr(freq_array[2],freq_array[3]),
            pokrovsiy.fsr(freq_array[3],freq_array[4]),
            pokrovsiy.fsr(freq_array[4],freq_array[5]),
            pokrovsiy.fsr(freq_array[5],freq_array[6]),
            pokrovsiy.fsr(freq_array[6],freq_array[7]),
            pokrovsiy.fsr(freq_array[7],freq_array[8]),
            pokrovsiy.fsr(freq_array[8],freq_array[9]),
            pokrovsiy.fsr(freq_array[9],freq_array[10]),
            pokrovsiy.fsr(freq_array[10],freq_array[11]),
            pokrovsiy.fsr(freq_array[11],freq_array[12]),
            pokrovsiy.fsr(freq_array[12],freq_array[13]),
            pokrovsiy.fsr(freq_array[13],freq_array[14]),
            pokrovsiy.fsr(freq_array[14],freq_array[15]),
            pokrovsiy.fsr(freq_array[15],freq_array[16]),
            pokrovsiy.fsr(freq_array[16],freq_array[17]),
            pokrovsiy.fsr(freq_array[17],freq_array[18]),
            pokrovsiy.fsr(freq_array[18],freq_array[19]),
            pokrovsiy.fsr(freq_array[19],freq_array[20])
        };

        double[] kf = new double[]
        {
            pokrovsiy.kf(fi[0]),
            pokrovsiy.kf(fi[1]),
            pokrovsiy.kf(fi[2]),
            pokrovsiy.kf(fi[3]),
            pokrovsiy.kf(fi[4]),
            pokrovsiy.kf(fi[5]),
            pokrovsiy.kf(fi[6]),
            pokrovsiy.kf(fi[7]),
            pokrovsiy.kf(fi[8]),
            pokrovsiy.kf(fi[9]),
            pokrovsiy.kf(fi[10]),
            pokrovsiy.kf(fi[11]),
            pokrovsiy.kf(fi[12]),
            pokrovsiy.kf(fi[13]),
            pokrovsiy.kf(fi[14]),
            pokrovsiy.kf(fi[15]),
            pokrovsiy.kf(fi[16]),
            pokrovsiy.kf(fi[17]),
            pokrovsiy.kf(fi[18]),
            pokrovsiy.kf(fi[19])
        };

        double[] delAi = new double[]
        {
            pokrovsiy.delAf(fi[0]),
            pokrovsiy.delAf(fi[1]),
            pokrovsiy.delAf(fi[2]),
            pokrovsiy.delAf(fi[3]),
            pokrovsiy.delAf(fi[4]),
            pokrovsiy.delAf(fi[5]),
            pokrovsiy.delAf(fi[6]),
            pokrovsiy.delAf(fi[7]),
            pokrovsiy.delAf(fi[8]),
            pokrovsiy.delAf(fi[9]),
            pokrovsiy.delAf(fi[10]),
            pokrovsiy.delAf(fi[11]),
            pokrovsiy.delAf(fi[12]),
            pokrovsiy.delAf(fi[13]),
            pokrovsiy.delAf(fi[14]),
            pokrovsiy.delAf(fi[15]),
            pokrovsiy.delAf(fi[16]),
            pokrovsiy.delAf(fi[17]),
            pokrovsiy.delAf(fi[18]),
            pokrovsiy.delAf(fi[19])
        };

        double[] ki = new double[]
        {
            pokrovsiy.ki(100.0, 420.0),
            pokrovsiy.ki(420.0, 570.0),
            pokrovsiy.ki(570.0, 710.0),
            pokrovsiy.ki(710.0, 865.0),
            pokrovsiy.ki(865.0, 1030.0),
            pokrovsiy.ki(1030.0, 1220.0),
            pokrovsiy.ki(1220.0, 1410.0),
            pokrovsiy.ki(1410.0, 1600.0),
            pokrovsiy.ki(1600.0, 1780.0),
            pokrovsiy.ki(1780.0, 1960.0),
            pokrovsiy.ki(1960.0, 2140.0),
            pokrovsiy.ki(2140.0, 2320.0),
            pokrovsiy.ki(2320.0, 2550.0),
            pokrovsiy.ki(2550.0, 2900.0),
            pokrovsiy.ki(2900.0, 3300.0),
            pokrovsiy.ki(3300.0, 3660.0),
            pokrovsiy.ki(3660.0, 4050.0),
            pokrovsiy.ki(4050.0, 5010.0),
            pokrovsiy.ki(5010.0, 7250.0),
            pokrovsiy.ki(7250.0, 10000.0)
        };

        double[] qi = new double[]
        {
            pokrovsiy.qi(Ls, L0[0]),
            pokrovsiy.qi(Ls, L0[1]),
            pokrovsiy.qi(Ls, L0[2]),
            pokrovsiy.qi(Ls, L0[3]),
            pokrovsiy.qi(Ls, L0[4]),
            pokrovsiy.qi(Ls, L0[5]),
            pokrovsiy.qi(Ls, L0[6]),
            pokrovsiy.qi(Ls, L0[7]),
            pokrovsiy.qi(Ls, L0[8]),
            pokrovsiy.qi(Ls, L0[9]),
            pokrovsiy.qi(Ls, L0[10]),
            pokrovsiy.qi(Ls, L0[11]),
            pokrovsiy.qi(Ls, L0[12]),
            pokrovsiy.qi(Ls, L0[13]),
            pokrovsiy.qi(Ls, L0[14]),
            pokrovsiy.qi(Ls, L0[15]),
            pokrovsiy.qi(Ls, L0[16]),
            pokrovsiy.qi(Ls, L0[17]),
            pokrovsiy.qi(Ls, L0[18]),
            pokrovsiy.qi(Ls, L0[19])
        };

        double[] Qi = new double[]
        {
            pokrovsiy.Qi(qi[0], delAi[0]),
            pokrovsiy.Qi(qi[1], delAi[1]),
            pokrovsiy.Qi(qi[2], delAi[2]),
            pokrovsiy.Qi(qi[3], delAi[3]),
            pokrovsiy.Qi(qi[4], delAi[4]),
            pokrovsiy.Qi(qi[5], delAi[5]),
            pokrovsiy.Qi(qi[6], delAi[6]),
            pokrovsiy.Qi(qi[7], delAi[7]),
            pokrovsiy.Qi(qi[8], delAi[8]),
            pokrovsiy.Qi(qi[9], delAi[9]),
            pokrovsiy.Qi(qi[10], delAi[10]),
            pokrovsiy.Qi(qi[11], delAi[11]),
            pokrovsiy.Qi(qi[12], delAi[12]),
            pokrovsiy.Qi(qi[13], delAi[13]),
            pokrovsiy.Qi(qi[14], delAi[14]),
            pokrovsiy.Qi(qi[15], delAi[15]),
            pokrovsiy.Qi(qi[16], delAi[16]),
            pokrovsiy.Qi(qi[17], delAi[17]),
            pokrovsiy.Qi(qi[18], delAi[18]),
            pokrovsiy.Qi(qi[19], delAi[19])
        };

        double[] pi = new double[]
        {
            pokrovsiy.pi(Qi[0]),
            pokrovsiy.pi(Qi[1]),
            pokrovsiy.pi(Qi[2]),
            pokrovsiy.pi(Qi[3]),
            pokrovsiy.pi(Qi[4]),
            pokrovsiy.pi(Qi[5]),
            pokrovsiy.pi(Qi[6]),
            pokrovsiy.pi(Qi[7]),
            pokrovsiy.pi(Qi[8]),
            pokrovsiy.pi(Qi[9]),
            pokrovsiy.pi(Qi[10]),
            pokrovsiy.pi(Qi[11]),
            pokrovsiy.pi(Qi[12]),
            pokrovsiy.pi(Qi[13]),
            pokrovsiy.pi(Qi[14]),
            pokrovsiy.pi(Qi[15]),
            pokrovsiy.pi(Qi[16]),
            pokrovsiy.pi(Qi[17]),
            pokrovsiy.pi(Qi[18]),
            pokrovsiy.pi(Qi[19])
        };

        double[] Ri = new double[]
        {
            pokrovsiy.Ri(pi[0], ki[0]),
            pokrovsiy.Ri(pi[1], ki[1]),
            pokrovsiy.Ri(pi[2], ki[2]),
            pokrovsiy.Ri(pi[3], ki[3]),
            pokrovsiy.Ri(pi[4], ki[4]),
            pokrovsiy.Ri(pi[5], ki[5]),
            pokrovsiy.Ri(pi[6], ki[6]),
            pokrovsiy.Ri(pi[7], ki[7]),
            pokrovsiy.Ri(pi[8], ki[8]),
            pokrovsiy.Ri(pi[9], ki[9]),
            pokrovsiy.Ri(pi[10], ki[10]),
            pokrovsiy.Ri(pi[11], ki[11]),
            pokrovsiy.Ri(pi[12], ki[12]),
            pokrovsiy.Ri(pi[13], ki[13]),
            pokrovsiy.Ri(pi[14], ki[14]),
            pokrovsiy.Ri(pi[15], ki[15]),
            pokrovsiy.Ri(pi[16], ki[16]),
            pokrovsiy.Ri(pi[17], ki[17]),
            pokrovsiy.Ri(pi[18], ki[18]),
            pokrovsiy.Ri(pi[19], ki[19])
        };

        WallOutput.Add(new TableData {Octave_Number = "1",  fn = "100",  fv = "420",   fi = fi[0].ToString("F4"),  Kf = kf[0].ToString("F2"),  delAi = delAi[0].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[0].ToString("F2"),  qi = qi[0].ToString("F2"),  Qi = Qi[0].ToString("F2"),  ki = ki[0].ToString("F2"),  pi = pi[0].ToString("F10"),  Ri = Ri[0].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "2",  fn = "420",  fv = "570",   fi = fi[1].ToString("F4"),  Kf = kf[1].ToString("F2"),  delAi = delAi[1].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[1].ToString("F2"),  qi = qi[1].ToString("F2"),  Qi = Qi[1].ToString("F2"),  ki = ki[1].ToString("F2"),  pi = pi[1].ToString("F10"),  Ri = Ri[1].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "3",  fn = "570",  fv = "710",   fi = fi[2].ToString("F4"),  Kf = kf[2].ToString("F2"),  delAi = delAi[2].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[2].ToString("F2"),  qi = qi[2].ToString("F2"),  Qi = Qi[2].ToString("F2"),  ki = ki[2].ToString("F2"),  pi = pi[2].ToString("F10"),  Ri = Ri[2].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "4",  fn = "710",  fv = "865",   fi = fi[3].ToString("F4"),  Kf = kf[3].ToString("F2"),  delAi = delAi[3].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[3].ToString("F2"),  qi = qi[3].ToString("F2"),  Qi = Qi[3].ToString("F2"),  ki = ki[3].ToString("F2"),  pi = pi[3].ToString("F10"),  Ri = Ri[3].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "5",  fn = "865",  fv = "1030",  fi = fi[4].ToString("F4"),  Kf = kf[4].ToString("F2"),  delAi = delAi[4].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[4].ToString("F2"),  qi = qi[4].ToString("F2"),  Qi = Qi[4].ToString("F2"),  ki = ki[4].ToString("F2"),  pi = pi[4].ToString("F10"),  Ri = Ri[4].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "6",  fn = "1030", fv = "1220",  fi = fi[5].ToString("F4"),  Kf = kf[5].ToString("F2"),  delAi = delAi[5].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[5].ToString("F2"),  qi = qi[5].ToString("F2"),  Qi = Qi[5].ToString("F2"),  ki = ki[5].ToString("F2"),  pi = pi[5].ToString("F10"),  Ri = Ri[5].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "7",  fn = "1220", fv = "1410",  fi = fi[6].ToString("F4"),  Kf = kf[6].ToString("F2"),  delAi = delAi[6].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[6].ToString("F2"),  qi = qi[6].ToString("F2"),  Qi = Qi[6].ToString("F2"),  ki = ki[6].ToString("F2"),  pi = pi[6].ToString("F10"),  Ri = Ri[6].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "8",  fn = "1410", fv = "1600",  fi = fi[7].ToString("F4"),  Kf = kf[7].ToString("F2"),  delAi = delAi[7].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[7].ToString("F2"),  qi = qi[7].ToString("F2"),  Qi = Qi[7].ToString("F2"),  ki = ki[7].ToString("F2"),  pi = pi[7].ToString("F10"),  Ri = Ri[7].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "9",  fn = "1600", fv = "1780",  fi = fi[8].ToString("F4"),  Kf = kf[8].ToString("F2"),  delAi = delAi[8].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[8].ToString("F2"),  qi = qi[8].ToString("F2"),  Qi = Qi[8].ToString("F2"),  ki = ki[8].ToString("F2"),  pi = pi[8].ToString("F10"),  Ri = Ri[8].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "10", fn = "1780", fv = "1960",  fi = fi[9].ToString("F4"),  Kf = kf[9].ToString("F2"),  delAi = delAi[9].ToString("F2"),  Ls = Ls.ToString("F2"), Lw = L0[9].ToString("F2"),  qi = qi[9].ToString("F2"),  Qi = Qi[9].ToString("F2"),  ki = ki[9].ToString("F2"),  pi = pi[9].ToString("F10"),  Ri = Ri[9].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "11", fn = "1960", fv = "2140",  fi = fi[10].ToString("F4"), Kf = kf[10].ToString("F2"), delAi = delAi[10].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[10].ToString("F2"), qi = qi[10].ToString("F2"), Qi = Qi[10].ToString("F2"), ki = ki[10].ToString("F2"), pi = pi[10].ToString("F10"), Ri = Ri[10].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "12", fn = "2140", fv = "2320",  fi = fi[11].ToString("F4"), Kf = kf[11].ToString("F2"), delAi = delAi[11].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[11].ToString("F2"), qi = qi[11].ToString("F2"), Qi = Qi[11].ToString("F2"), ki = ki[11].ToString("F2"), pi = pi[11].ToString("F10"), Ri = Ri[11].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "13", fn = "2320", fv = "2550",  fi = fi[12].ToString("F4"), Kf = kf[12].ToString("F2"), delAi = delAi[12].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[12].ToString("F2"), qi = qi[12].ToString("F2"), Qi = Qi[12].ToString("F2"), ki = ki[12].ToString("F2"), pi = pi[12].ToString("F10"), Ri = Ri[12].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "14", fn = "2550", fv = "2900",  fi = fi[13].ToString("F4"), Kf = kf[13].ToString("F2"), delAi = delAi[13].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[13].ToString("F2"), qi = qi[13].ToString("F2"), Qi = Qi[13].ToString("F2"), ki = ki[13].ToString("F2"), pi = pi[13].ToString("F10"), Ri = Ri[13].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "15", fn = "2900", fv = "3300",  fi = fi[14].ToString("F4"), Kf = kf[14].ToString("F2"), delAi = delAi[14].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[14].ToString("F2"), qi = qi[14].ToString("F2"), Qi = Qi[14].ToString("F2"), ki = ki[14].ToString("F2"), pi = pi[14].ToString("F10"), Ri = Ri[14].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "16", fn = "3300", fv = "3660",  fi = fi[15].ToString("F4"), Kf = kf[15].ToString("F2"), delAi = delAi[15].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[15].ToString("F2"), qi = qi[15].ToString("F2"), Qi = Qi[15].ToString("F2"), ki = ki[15].ToString("F2"), pi = pi[15].ToString("F10"), Ri = Ri[15].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "17", fn = "3660", fv = "4050",  fi = fi[16].ToString("F4"), Kf = kf[16].ToString("F2"), delAi = delAi[16].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[16].ToString("F2"), qi = qi[16].ToString("F2"), Qi = Qi[16].ToString("F2"), ki = ki[16].ToString("F2"), pi = pi[16].ToString("F10"), Ri = Ri[16].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "18", fn = "4050", fv = "5010",  fi = fi[17].ToString("F4"), Kf = kf[17].ToString("F2"), delAi = delAi[17].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[17].ToString("F2"), qi = qi[17].ToString("F2"), Qi = Qi[17].ToString("F2"), ki = ki[17].ToString("F2"), pi = pi[17].ToString("F10"), Ri = Ri[17].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "19", fn = "5010", fv = "7250",  fi = fi[18].ToString("F4"), Kf = kf[18].ToString("F2"), delAi = delAi[18].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[18].ToString("F2"), qi = qi[18].ToString("F2"), Qi = Qi[18].ToString("F2"), ki = ki[18].ToString("F2"), pi = pi[18].ToString("F10"), Ri = Ri[18].ToString("F10") });
        WallOutput.Add(new TableData {Octave_Number = "20", fn = "7250", fv = "10000", fi = fi[19].ToString("F4"), Kf = kf[19].ToString("F2"), delAi = delAi[19].ToString("F2"), Ls = Ls.ToString("F2"), Lw = L0[19].ToString("F2"), qi = qi[19].ToString("F2"), Qi = Qi[19].ToString("F2"), ki = ki[19].ToString("F2"), pi = pi[19].ToString("F10"), Ri = Ri[19].ToString("F10") });
        
    }

    public ANSWER Result(double WallHeight, double WallLenght,
        double Sp, double r,
        int speechLevel, double VolLoudness)
    {
        Sp = WallHeight * WallLenght*Sp;
        double R = 0, SR = 0, WS = 0, WR = 0;


        List<Speech_Levels> speech_Levels = new List<Speech_Levels>
        {
            new Speech_Levels { type = "речь", AverageFrequency250 = 67.9, AverageFrequency500 = 66.9, AverageFrequency1000 = 61.5, AverageFrequency2000 = 57, AverageFrequency4000 = 53, AverageFrequency6000 = 48.5, Sum_Levels = 1},
            new Speech_Levels { type = "ПС-20", AverageFrequency250 = 31, AverageFrequency500 = 24, AverageFrequency1000 = 20, AverageFrequency2000 = 17, AverageFrequency4000 = 14, AverageFrequency6000 = 13, Sum_Levels = 32.3},
            new Speech_Levels { type = "ПС-25", AverageFrequency250 = 35, AverageFrequency500 = 29, AverageFrequency1000 = 25, AverageFrequency2000 = 22, AverageFrequency4000 = 20, AverageFrequency6000 = 18, Sum_Levels = 36.6},
            new Speech_Levels { type = "ПС-30", AverageFrequency250 = 40, AverageFrequency500 = 34, AverageFrequency1000 = 30, AverageFrequency2000 = 27, AverageFrequency4000 = 25, AverageFrequency6000 = 23, Sum_Levels = 41.6},
            new Speech_Levels { type = "ПС-35", AverageFrequency250 = 45, AverageFrequency500 = 39, AverageFrequency1000 = 35, AverageFrequency2000 = 32, AverageFrequency4000 = 30, AverageFrequency6000 = 28, Sum_Levels = 47},
            new Speech_Levels { type = "ПС-40", AverageFrequency250 = 49, AverageFrequency500 = 44, AverageFrequency1000 = 40, AverageFrequency2000 = 37, AverageFrequency4000 = 35, AverageFrequency6000 = 33, Sum_Levels = 51},
            new Speech_Levels { type = "ПС-45", AverageFrequency250 = 54, AverageFrequency500 = 49, AverageFrequency1000 = 45, AverageFrequency2000 = 42, AverageFrequency4000 = 40, AverageFrequency6000 = 38, Sum_Levels = 60},
            new Speech_Levels { type = "ПС-50", AverageFrequency250 = 59, AverageFrequency500 = 54, AverageFrequency1000 = 50, AverageFrequency2000 = 47, AverageFrequency4000 = 44, AverageFrequency6000 = 43, Sum_Levels = 61},
            new Speech_Levels { type = "ПС-55", AverageFrequency250 = 63, AverageFrequency500 = 59, AverageFrequency1000 = 55, AverageFrequency2000 = 52, AverageFrequency4000 = 50, AverageFrequency6000 = 49, Sum_Levels = 65},
        };

        Pokrovsiy pokrovsiy = new Pokrovsiy();

        double Ls = pokrovsiy.L(VolLoudness, Sp, r, 6);

        Sp = pokrovsiy.Sp(WallHeight, WallLenght);

        double[] L0 = new double[]
        {
            speech_Levels[speechLevel].AverageFrequency250,
            speech_Levels[speechLevel].AverageFrequency500,
            speech_Levels[speechLevel].AverageFrequency500,
            speech_Levels[speechLevel].AverageFrequency500,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency1000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency2000,
            speech_Levels[speechLevel].AverageFrequency4000,
            speech_Levels[speechLevel].AverageFrequency4000,
            speech_Levels[speechLevel].AverageFrequency6000,
            speech_Levels[speechLevel].AverageFrequency6000
        };

        double[] fi = new double[]
        {
            pokrovsiy.fsr(100.0, 420.0),
            pokrovsiy.fsr(420.0, 570.0),
            pokrovsiy.fsr(570.0, 710.0),
            pokrovsiy.fsr(710.0, 865.0),
            pokrovsiy.fsr(865.0, 1030.0),
            pokrovsiy.fsr(1030.0, 1220.0),
            pokrovsiy.fsr(1220.0, 1410.0),
            pokrovsiy.fsr(1410.0, 1600.0),
            pokrovsiy.fsr(1600.0, 1780.0),
            pokrovsiy.fsr(1780.0, 1960.0),
            pokrovsiy.fsr(1960.0, 2140.0),
            pokrovsiy.fsr(2140.0, 2320.0),
            pokrovsiy.fsr(2320.0, 2550.0),
            pokrovsiy.fsr(2550.0, 2900.0),
            pokrovsiy.fsr(2900.0, 3300.0),
            pokrovsiy.fsr(3300.0, 3660.0),
            pokrovsiy.fsr(3660.0, 4050.0),
            pokrovsiy.fsr(4050.0, 5010.0),
            pokrovsiy.fsr(5010.0, 7250.0),
            pokrovsiy.fsr(7250.0, 10000.0)
        };

        double[] kf = new double[]
        {
            pokrovsiy.kf(fi[0]),
            pokrovsiy.kf(fi[1]),
            pokrovsiy.kf(fi[2]),
            pokrovsiy.kf(fi[3]),
            pokrovsiy.kf(fi[4]),
            pokrovsiy.kf(fi[5]),
            pokrovsiy.kf(fi[6]),
            pokrovsiy.kf(fi[7]),
            pokrovsiy.kf(fi[8]),
            pokrovsiy.kf(fi[9]),
            pokrovsiy.kf(fi[10]),
            pokrovsiy.kf(fi[11]),
            pokrovsiy.kf(fi[12]),
            pokrovsiy.kf(fi[13]),
            pokrovsiy.kf(fi[14]),
            pokrovsiy.kf(fi[15]),
            pokrovsiy.kf(fi[16]),
            pokrovsiy.kf(fi[17]),
            pokrovsiy.kf(fi[18]),
            pokrovsiy.kf(fi[19])
        };

        double[] delAi = new double[]
        {
            pokrovsiy.delAf(fi[0]),
            pokrovsiy.delAf(fi[1]),
            pokrovsiy.delAf(fi[2]),
            pokrovsiy.delAf(fi[3]),
            pokrovsiy.delAf(fi[4]),
            pokrovsiy.delAf(fi[5]),
            pokrovsiy.delAf(fi[6]),
            pokrovsiy.delAf(fi[7]),
            pokrovsiy.delAf(fi[8]),
            pokrovsiy.delAf(fi[9]),
            pokrovsiy.delAf(fi[10]),
            pokrovsiy.delAf(fi[11]),
            pokrovsiy.delAf(fi[12]),
            pokrovsiy.delAf(fi[13]),
            pokrovsiy.delAf(fi[14]),
            pokrovsiy.delAf(fi[15]),
            pokrovsiy.delAf(fi[16]),
            pokrovsiy.delAf(fi[17]),
            pokrovsiy.delAf(fi[18]),
            pokrovsiy.delAf(fi[19])
        };

        double[] ki = new double[]
        {
            pokrovsiy.ki(100.0, 420.0),
            pokrovsiy.ki(420.0, 570.0),
            pokrovsiy.ki(570.0, 710.0),
            pokrovsiy.ki(710.0, 865.0),
            pokrovsiy.ki(865.0, 1030.0),
            pokrovsiy.ki(1030.0, 1220.0),
            pokrovsiy.ki(1220.0, 1410.0),
            pokrovsiy.ki(1410.0, 1600.0),
            pokrovsiy.ki(1600.0, 1780.0),
            pokrovsiy.ki(1780.0, 1960.0),
            pokrovsiy.ki(1960.0, 2140.0),
            pokrovsiy.ki(2140.0, 2320.0),
            pokrovsiy.ki(2320.0, 2550.0),
            pokrovsiy.ki(2550.0, 2900.0),
            pokrovsiy.ki(2900.0, 3300.0),
            pokrovsiy.ki(3300.0, 3660.0),
            pokrovsiy.ki(3660.0, 4050.0),
            pokrovsiy.ki(4050.0, 5010.0),
            pokrovsiy.ki(5010.0, 7250.0),
            pokrovsiy.ki(7250.0, 10000.0)
        };

        double[] qi = new double[]
        {
            pokrovsiy.qi(Ls, L0[0]),
            pokrovsiy.qi(Ls, L0[1]),
            pokrovsiy.qi(Ls, L0[2]),
            pokrovsiy.qi(Ls, L0[3]),
            pokrovsiy.qi(Ls, L0[4]),
            pokrovsiy.qi(Ls, L0[5]),
            pokrovsiy.qi(Ls, L0[6]),
            pokrovsiy.qi(Ls, L0[7]),
            pokrovsiy.qi(Ls, L0[8]),
            pokrovsiy.qi(Ls, L0[9]),
            pokrovsiy.qi(Ls, L0[10]),
            pokrovsiy.qi(Ls, L0[11]),
            pokrovsiy.qi(Ls, L0[12]),
            pokrovsiy.qi(Ls, L0[13]),
            pokrovsiy.qi(Ls, L0[14]),
            pokrovsiy.qi(Ls, L0[15]),
            pokrovsiy.qi(Ls, L0[16]),
            pokrovsiy.qi(Ls, L0[17]),
            pokrovsiy.qi(Ls, L0[18]),
            pokrovsiy.qi(Ls, L0[19])
        };

        double[] Qi = new double[]
        {
            pokrovsiy.Qi(qi[0], delAi[0]),
            pokrovsiy.Qi(qi[1], delAi[1]),
            pokrovsiy.Qi(qi[2], delAi[2]),
            pokrovsiy.Qi(qi[3], delAi[3]),
            pokrovsiy.Qi(qi[4], delAi[4]),
            pokrovsiy.Qi(qi[5], delAi[5]),
            pokrovsiy.Qi(qi[6], delAi[6]),
            pokrovsiy.Qi(qi[7], delAi[7]),
            pokrovsiy.Qi(qi[8], delAi[8]),
            pokrovsiy.Qi(qi[9], delAi[9]),
            pokrovsiy.Qi(qi[10], delAi[10]),
            pokrovsiy.Qi(qi[11], delAi[11]),
            pokrovsiy.Qi(qi[12], delAi[12]),
            pokrovsiy.Qi(qi[13], delAi[13]),
            pokrovsiy.Qi(qi[14], delAi[14]),
            pokrovsiy.Qi(qi[15], delAi[15]),
            pokrovsiy.Qi(qi[16], delAi[16]),
            pokrovsiy.Qi(qi[17], delAi[17]),
            pokrovsiy.Qi(qi[18], delAi[18]),
            pokrovsiy.Qi(qi[19], delAi[19])
        };

        double[] pi = new double[]
        {
            pokrovsiy.pi(Qi[0]),
            pokrovsiy.pi(Qi[1]),
            pokrovsiy.pi(Qi[2]),
            pokrovsiy.pi(Qi[3]),
            pokrovsiy.pi(Qi[4]),
            pokrovsiy.pi(Qi[5]),
            pokrovsiy.pi(Qi[6]),
            pokrovsiy.pi(Qi[7]),
            pokrovsiy.pi(Qi[8]),
            pokrovsiy.pi(Qi[9]),
            pokrovsiy.pi(Qi[10]),
            pokrovsiy.pi(Qi[11]),
            pokrovsiy.pi(Qi[12]),
            pokrovsiy.pi(Qi[13]),
            pokrovsiy.pi(Qi[14]),
            pokrovsiy.pi(Qi[15]),
            pokrovsiy.pi(Qi[16]),
            pokrovsiy.pi(Qi[17]),
            pokrovsiy.pi(Qi[18]),
            pokrovsiy.pi(Qi[19])
        };

        double[] Ri = new double[]
        {
            pokrovsiy.Ri(pi[0], ki[0]),
            pokrovsiy.Ri(pi[1], ki[1]),
            pokrovsiy.Ri(pi[2], ki[2]),
            pokrovsiy.Ri(pi[3], ki[3]),
            pokrovsiy.Ri(pi[4], ki[4]),
            pokrovsiy.Ri(pi[5], ki[5]),
            pokrovsiy.Ri(pi[6], ki[6]),
            pokrovsiy.Ri(pi[7], ki[7]),
            pokrovsiy.Ri(pi[8], ki[8]),
            pokrovsiy.Ri(pi[9], ki[9]),
            pokrovsiy.Ri(pi[10], ki[10]),
            pokrovsiy.Ri(pi[11], ki[11]),
            pokrovsiy.Ri(pi[12], ki[12]),
            pokrovsiy.Ri(pi[13], ki[13]),
            pokrovsiy.Ri(pi[14], ki[14]),
            pokrovsiy.Ri(pi[15], ki[15]),
            pokrovsiy.Ri(pi[16], ki[16]),
            pokrovsiy.Ri(pi[17], ki[17]),
            pokrovsiy.Ri(pi[18], ki[18]),
            pokrovsiy.Ri(pi[19], ki[19])
        };

        ANSWER ans = new ANSWER();
        R = Ri.Sum();
        ans.R = R.ToString("F10"); ans.WR = pokrovsiy.W(R).ToString("F10"); ans.SR = pokrovsiy.S(R).ToString("F10"); ans.WS = pokrovsiy.WS(pokrovsiy.S(R)).ToString("F10");

        return (ans);
    }



    #region Рассчет первой стены
    public void GetFirstWallResult(string sWallHeight, string sWallLenght,
        string sWindow_par1, string sWindow_par2,
        string sDoor_par1, string sDoor_par2,
        string sWallMaterial_par1, string sWallMaterial_par2,
        string sRadiator_par1, string sRadiator_par2,
        int Speechlevel, double VolLoudness, double[] freq_array)
    {
        double WallHeight_Num, WallLenght_Num, 
            Window_par1, Window_par2,
            Door_par1, Door_par2,
            WallMaterial_par1, WallMaterial_par2,
            Radiator_par1, Radiator_par2;

        try { WallHeight_Num = Convert.ToDouble(sWallHeight); } catch { WallHeight_Num = 0; }
        try { WallLenght_Num = Convert.ToDouble(sWallLenght); } catch { WallLenght_Num = 0; }

        try { Window_par1 = Convert.ToDouble(sWindow_par1); } catch { Window_par1 = 0; }
        try { Window_par2 = Convert.ToDouble(sWindow_par2); } catch { Window_par2 = 0; }

        try { Door_par1 = Convert.ToDouble(sDoor_par1); } catch { Door_par1 = 0; }
        try { Door_par2 = Convert.ToDouble(sDoor_par2); } catch { Door_par2 = 0; }

        try { WallMaterial_par1 = Convert.ToDouble(sWallMaterial_par1); } catch { WallMaterial_par1 = 0; }
        try { WallMaterial_par2 = Convert.ToDouble(sWallMaterial_par2); } catch { WallMaterial_par2 = 0; }

        
        try { Radiator_par1 = Convert.ToDouble(sRadiator_par1); } catch { Radiator_par1 = 0; }
        try { Radiator_par2 = Convert.ToDouble(sRadiator_par2); } catch { Radiator_par2 = 0; }
        //стена дверь окно радиатор
        if ((WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
        WallResult(WallHeight_Num, WallLenght_Num, 1,WallMaterial_par1,
            Speechlevel, VolLoudness, FirstWallOutput1, freq_array);
        if ((Door_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Door_par2, Door_par1,
                Speechlevel, VolLoudness, FirstWallOutput2, freq_array);
        if ((Window_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Window_par2, Window_par1,
            Speechlevel, VolLoudness, FirstWallOutput3, freq_array);
        if ((Radiator_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Radiator_par2, Radiator_par1,
            Speechlevel, VolLoudness, FirstWallOutput4, freq_array);
    }
    #endregion
    
    #region Рассчет второй стены
    public void GetSecondWallResult(string sWallHeight, string sWallLenght,
        string sWindow_par1, string sWindow_par2,
        string sDoor_par1, string sDoor_par2,
        string sWallMaterial_par1, string sWallMaterial_par2,
        string sRadiator_par1, string sRadiator_par2,
        int Speechlevel, double VolLoudness, double[] freq_array)
    {
        double WallHeight_Num, WallLenght_Num,
            Window_par1, Window_par2,
            Door_par1, Door_par2,
            WallMaterial_par1, WallMaterial_par2,
            Radiator_par1, Radiator_par2;

        try { WallHeight_Num = Convert.ToDouble(sWallHeight); } catch { WallHeight_Num = 0; }
        try { WallLenght_Num = Convert.ToDouble(sWallLenght); } catch { WallLenght_Num = 0; }

        try { Window_par1 = Convert.ToDouble(sWindow_par1); } catch { Window_par1 = 0; }
        try { Window_par2 = Convert.ToDouble(sWindow_par2); } catch { Window_par2 = 0; }

        try { Door_par1 = Convert.ToDouble(sDoor_par1); } catch { Door_par1 = 0; }
        try { Door_par2 = Convert.ToDouble(sDoor_par2); } catch { Door_par2 = 0; }

        try { WallMaterial_par1 = Convert.ToDouble(sWallMaterial_par1); } catch { WallMaterial_par1 = 0; }
        try { WallMaterial_par2 = Convert.ToDouble(sWallMaterial_par2); } catch { WallMaterial_par2 = 0; }


        try { Radiator_par1 = Convert.ToDouble(sRadiator_par1); } catch { Radiator_par1 = 0; }
        try { Radiator_par2 = Convert.ToDouble(sRadiator_par2); } catch { Radiator_par2 = 0; }

        if ((WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, 1, WallMaterial_par1,
                Speechlevel, VolLoudness, SecondWallOutput1, freq_array);
        if ((Door_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Door_par2, Door_par1,
                Speechlevel, VolLoudness, SecondWallOutput2, freq_array);
        if ((Window_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Window_par2, Window_par1,
            Speechlevel, VolLoudness, SecondWallOutput3, freq_array);
        if ((Radiator_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Radiator_par2, Radiator_par1,
            Speechlevel, VolLoudness, SecondWallOutput4, freq_array);
    }   
    #endregion
    
    #region Рассчет третьей стены
    public void GetThirdWallResult(string sWallHeight, string sWallLenght,
        string sWindow_par1, string sWindow_par2,
        string sDoor_par1, string sDoor_par2,
        string sWallMaterial_par1, string sWallMaterial_par2,
        string sRadiator_par1, string sRadiator_par2,
        int Speechlevel, double VolLoudness, double[] freq_array)
    {
        double WallHeight_Num, WallLenght_Num,
            Window_par1, Window_par2,
            Door_par1, Door_par2,
            WallMaterial_par1, WallMaterial_par2,
            Radiator_par1, Radiator_par2;

        try { WallHeight_Num = Convert.ToDouble(sWallHeight); } catch { WallHeight_Num = 0; }
        try { WallLenght_Num = Convert.ToDouble(sWallLenght); } catch { WallLenght_Num = 0; }

        try { Window_par1 = Convert.ToDouble(sWindow_par1); } catch { Window_par1 = 0; }
        try { Window_par2 = Convert.ToDouble(sWindow_par2); } catch { Window_par2 = 0; }

        try { Door_par1 = Convert.ToDouble(sDoor_par1); } catch { Door_par1 = 0; }
        try { Door_par2 = Convert.ToDouble(sDoor_par2); } catch { Door_par2 = 0; }

        try { WallMaterial_par1 = Convert.ToDouble(sWallMaterial_par1); } catch { WallMaterial_par1 = 0; }
        try { WallMaterial_par2 = Convert.ToDouble(sWallMaterial_par2); } catch { WallMaterial_par2 = 0; }


        try { Radiator_par1 = Convert.ToDouble(sRadiator_par1); } catch { Radiator_par1 = 0; }
        try { Radiator_par2 = Convert.ToDouble(sRadiator_par2); } catch { Radiator_par2 = 0; }

        if ((WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, 1, WallMaterial_par1,
                Speechlevel, VolLoudness, ThirdWallOutput1, freq_array);
        if ((Door_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Door_par2, Door_par1,
                Speechlevel, VolLoudness, ThirdWallOutput2, freq_array);
        if ((Window_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Window_par2, Window_par1,
            Speechlevel, VolLoudness, ThirdWallOutput3, freq_array);
        if ((Radiator_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Radiator_par2, Radiator_par1,
            Speechlevel, VolLoudness, ThirdWallOutput4, freq_array);
    }
    #endregion
    
    #region Рассчет четвертой стены
    public void GetFourthWallResult(string sWallHeight, string sWallLenght,
        string sWindow_par1, string sWindow_par2,
        string sDoor_par1, string sDoor_par2,
        string sWallMaterial_par1, string sWallMaterial_par2,
        string sRadiator_par1, string sRadiator_par2,
        int Speechlevel, double VolLoudness, double[] freq_array)
    {
        double WallHeight_Num, WallLenght_Num,
            Window_par1, Window_par2,
            Door_par1, Door_par2,
            WallMaterial_par1, WallMaterial_par2,
            Radiator_par1, Radiator_par2;

        try { WallHeight_Num = Convert.ToDouble(sWallHeight); } catch { WallHeight_Num = 0; }
        try { WallLenght_Num = Convert.ToDouble(sWallLenght); } catch { WallLenght_Num = 0; }

        try { Window_par1 = Convert.ToDouble(sWindow_par1); } catch { Window_par1 = 0; }
        try { Window_par2 = Convert.ToDouble(sWindow_par2); } catch { Window_par2 = 0; }

        try { Door_par1 = Convert.ToDouble(sDoor_par1); } catch { Door_par1 = 0; }
        try { Door_par2 = Convert.ToDouble(sDoor_par2); } catch { Door_par2 = 0; }

        try { WallMaterial_par1 = Convert.ToDouble(sWallMaterial_par1); } catch { WallMaterial_par1 = 0; }
        try { WallMaterial_par2 = Convert.ToDouble(sWallMaterial_par2); } catch { WallMaterial_par2 = 0; }


        try { Radiator_par1 = Convert.ToDouble(sRadiator_par1); } catch { Radiator_par1 = 0; }
        try { Radiator_par2 = Convert.ToDouble(sRadiator_par2); } catch { Radiator_par2 = 0; }

        if ((WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, 1, WallMaterial_par1,
                Speechlevel, VolLoudness, FourthWallOutput1, freq_array);
        if ((Door_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Door_par2, Door_par1,
                Speechlevel, VolLoudness, FourthWallOutput2, freq_array);
        if ((Window_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Window_par2, Window_par1,
            Speechlevel, VolLoudness, FourthWallOutput3, freq_array);
        if ((Radiator_par2 != 0) && (WallHeight_Num != 0) && (WallLenght_Num != 0) && (VolLoudness != 0))
            WallResult(WallHeight_Num, WallLenght_Num, Radiator_par2, Radiator_par1,
            Speechlevel, VolLoudness, FourthWallOutput4, freq_array);
    }
    #endregion
}

