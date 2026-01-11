/*using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization; 
using System.Linq; // Char များကို စစ်ဆေးရန်

namespace _6週目_MYAT_THADAR_LINN_Vicroty_Fall
{
    public partial class MainWindow : Window
    {
        // #####################################################################
        // #           အပိုင်း (၁): ကိန်းရှင်များ (Variables)                   #
        // #           Bug Fix: double အစား decimal ကို အသုံးပြုသည်             #
        // #####################################################################

        private decimal firstNumber = 0; // double အစား decimal ကို အသုံးပြုသည်
        private string operation = string.Empty;
        private bool isNewNumber = true;
        private decimal memoryValue = 0; // double အစား decimal ကို အသုံးပြုသည်

        private bool isBurmeseMode = false;

        public MainWindow()
        {
            InitializeComponent();
            AttachNumberButtons();
            AttachOperatorButtons();
            UpdateModeUI();
        }

        // #####################################################################
        // #           အပိုင်း (၂): Helper Methods: ဂဏန်း ပြောင်းလဲခြင်း       #
        // #####################################################################

        private string ConvertToEnglishDigits(string text)
        {
            text = text.Replace('၀', '0').Replace('၁', '1').Replace('၂', '2').Replace('၃', '3').Replace('၄', '4')
                         .Replace('၅', '5').Replace('၆', '6').Replace('၇', '7').Replace('၈', '8').Replace('၉', '9')
                         .Replace("ဒသမ", ".");
            return text;
        }

        private string ConvertToBurmeseDigits(string text)
        {
            text = text.Replace('0', '၀').Replace('1', '၁').Replace('2', '၂').Replace('3', '၃').Replace('4', '၄')
                         .Replace('5', '၅').Replace('6', '၆').Replace('7', '၇').Replace('8', '၈').Replace('9', '၉');
            // English decimal point ကို မြန်မာ ဒသမသို့ ပြောင်းသည်
            text = text.Replace(".", "ဒသမ");
            return text;
        }

        private void UpdateModeUI()
        {
            string currentDisplay = ConvertToEnglishDigits(DisplayTextBlock.Text);

            if (isBurmeseMode)
            {
                ModeTextBlock.Text = "မုဒ်: မြန်မာ";
                Btn0.Content = "၀"; Btn1.Content = "၁"; Btn2.Content = "၂";
                Btn3.Content = "၃"; Btn4.Content = "၄"; Btn5.Content = "၅";
                Btn6.Content = "၆"; Btn7.Content = "၇"; Btn8.Content = "၈";
                Btn9.Content = "၉";
                BtnAC.Content = "ရှင်း"; BtnDEL.Content = "ဖြုတ်";
                BtnDecimal.Content = "ဒသမ";
                BtnEqual.Content = "ညီမျှ";
                BtnMC.Content = "Mရ"; BtnMR.Content = "Mခေါ်";

                DisplayTextBlock.Text = ConvertToBurmeseDigits(currentDisplay);
            }
            else
            {
                ModeTextBlock.Text = "Mode: English";
                Btn0.Content = "0"; Btn1.Content = "1"; Btn2.Content = "2";
                Btn3.Content = "3"; Btn4.Content = "4"; Btn5.Content = "5";
                Btn6.Content = "6"; Btn7.Content = "7"; Btn8.Content = "8";
                Btn9.Content = "9";
                BtnAC.Content = "AC"; BtnDEL.Content = "DEL";
                BtnDecimal.Content = ".";
                BtnEqual.Content = "=";
                BtnMC.Content = "MC"; BtnMR.Content = "MR";

                DisplayTextBlock.Text = currentDisplay;
            }
        }

        // #####################################################################
        // #           အပိုင်း (၃): ခလုတ် Event များ ချိတ်ဆက်ခြင်း (Initialization)   #
        // #####################################################################

        private void AttachNumberButtons()
        {
            Btn0.Click += NumberButton_Click; Btn1.Click += NumberButton_Click;
            Btn2.Click += NumberButton_Click; Btn3.Click += NumberButton_Click;
            Btn4.Click += NumberButton_Click; Btn5.Click += NumberButton_Click;
            Btn6.Click += NumberButton_Click; Btn7.Click += NumberButton_Click;
            Btn8.Click += NumberButton_Click; Btn9.Click += NumberButton_Click;
            BtnDecimal.Click += NumberButton_Click;
        }

        private void AttachOperatorButtons()
        {
            BtnAdd.Click += OperatorButton_Click;
            BtnSubtract.Click += OperatorButton_Click;
            BtnMultiply.Click += OperatorButton_Click;
            BtnDivide.Click += OperatorButton_Click;
            BtnPercent.Click += OperatorButton_Click;

            BtnAC.Click += BtnAC_Click;
            BtnDEL.Click += BtnDEL_Click;
            BtnEqual.Click += BtnEqual_Click;
            BtnMC.Click += BtnMC_Click;
            BtnMR.Click += BtnMR_Click;
            BtnMPlus.Click += BtnMPlus_Click;
            BtnMMinus.Click += BtnMMinus_Click;

            BtnGlobe.Click += BtnGlobe_Click;
        }

        // #####################################################################
        // #           အပိုင်း (၄.၅): Helper Logic Methods (Bugs ပြင်ရန်)        #
        // #####################################################################

        // Bug Fix: decimal ဖြင့် ပြောင်းလဲသည်
        private decimal PerformCalculation(decimal secondNumber, string currentOperation)
        {
            decimal result=0;

            switch (currentOperation)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "X": result = firstNumber * secondNumber; break;
                case "÷": result = firstNumber / secondNumber; break;
                case "%": result = firstNumber/100; break;
                    //    if (secondNumber != 0)
                    //    {
                    //        result = firstNumber / secondNumber;
                    //    }
                    //    else
                    //    {
                    //        throw new DivideByZeroException("Division by zero.");
                    //    }
                    //    break;
                    //case "%":
                    //       string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
                    //    if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
                    //    {
                    //        decimal percentValue = currentNumber / 100;
                    //        UpdateDisplayWithResult(percentValue);
                    //        isNewNumber = true;
                    //    }
                    //     break;

            }
           return result;
        }

        // Bug Fix: decimal ကို ကိုင်တွယ်
        private void UpdateDisplayWithResult(decimal result)
        {
            // ရလဒ်ကို 10 နေရာအထိ ကန့်သတ်ပြီး ToString() ကို InvariantCulture ဖြင့် ခေါ်

            string resultString = Math.Round(result, 10).ToString(CultureInfo.InvariantCulture);

            DisplayTextBlock.Text = isBurmeseMode ? ConvertToBurmeseDigits(resultString) : resultString;
        }

        // #####################################################################
        // #           အပိုင်း (၄): ဂဏန်းနှင့် Operator Logic (Core Logic)         #
        // #####################################################################

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            string newDigitContent = ((Button)sender).Content.ToString();

            if (isNewNumber)
            {
                DisplayTextBlock.Text = "";
                isNewNumber = false;
            }

            if (newDigitContent == "." || newDigitContent == "ဒသမ")
            {
                if (!DisplayTextBlock.Text.Contains(".") && !DisplayTextBlock.Text.Contains("ဒသမ"))
                {
                    DisplayTextBlock.Text += isBurmeseMode ? "ဒသမ" : ".";
                }
            }
            else
            {
                DisplayTextBlock.Text += newDigitContent;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);

            // Bug Fix: decimal.TryParse ကို သုံးသည်
            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
            {
                string newOperation = ((Button)sender).Content.ToString();

                // Bug Fix: Continuous Addition Logic
                if (!string.IsNullOrEmpty(operation) && !isNewNumber)
                {
                    try
                    {
                        decimal result = PerformCalculation(currentNumber, operation);
                        UpdateDisplayWithResult(result);
                        firstNumber = result;
                    }
                    catch (DivideByZeroException)
                    {
                        DisplayTextBlock.Text = "Error: Div by zero";
                        firstNumber = 0;
                        operation = string.Empty;
                        isNewNumber = true;
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(operation))
                {
                    firstNumber = currentNumber;
                }

                operation = newOperation;
                isNewNumber = true;
            }
        }

        // #####################################################################
        // #           အပိုင်း (၅): အထူးလုပ်ဆောင်ချက်များ (Special Functions)        #
        // #####################################################################

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            firstNumber = 0;
            operation = string.Empty;
            isNewNumber = true;
            DisplayTextBlock.Text = isBurmeseMode ? "၀" : "0";
        }

        private void BtnDEL_Click(object sender, RoutedEventArgs e)
        {
            if (DisplayTextBlock.Text.Length > 1)
            {
                DisplayTextBlock.Text = DisplayTextBlock.Text.Substring(0, DisplayTextBlock.Text.Length - 1);
            }
            else
            {
                DisplayTextBlock.Text = isBurmeseMode ? "၀" : "0";
            }
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            if (operation == string.Empty) return;

            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
            string previousOperation = operation;

            // Bug Fix: decimal.TryParse ကို သုံးသည်
            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal secondNumber))
            {
                try
                {
                    decimal result = PerformCalculation(secondNumber, previousOperation);

                    UpdateDisplayWithResult(result);

                    firstNumber = result;
                    operation = string.Empty;
                    isNewNumber = true;
                }
                catch (DivideByZeroException)
                {
                    DisplayTextBlock.Text = "Error: Div by zero";
                    firstNumber = 0;
                    operation = string.Empty;
                    isNewNumber = true;
                }
            }
        }

        // #####################################################################
        // #           အပိုင်း (၆): Memory Logic (M Functions) / Globe              #
        // #####################################################################

        private void BtnMC_Click(object sender, RoutedEventArgs e)
        {
            memoryValue = 0;
            isNewNumber = true;
        }

        private void BtnMR_Click(object sender, RoutedEventArgs e)
        {
            string memoryString = memoryValue.ToString(CultureInfo.InvariantCulture);
            DisplayTextBlock.Text = isBurmeseMode ? ConvertToBurmeseDigits(memoryString) : memoryString;
            isNewNumber = true;
        }

        private void BtnMPlus_Click(object sender, RoutedEventArgs e)
        {
            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
            // Bug Fix: decimal.TryParse ကို သုံးသည်
            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
            {
                memoryValue += currentNumber;
                isNewNumber = true;
            }
        }

        private void BtnMMinus_Click(object sender, RoutedEventArgs e)
        {
            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
            // Bug Fix: decimal.TryParse ကို သုံးသည်
            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
            {
                memoryValue -= currentNumber;
                isNewNumber = true;
            }
        }

        private void BtnGlobe_Click(object sender, RoutedEventArgs e)
        {
            isBurmeseMode = !isBurmeseMode;
            UpdateModeUI();
        }

        
    }
}
*/
                                             //VICTORY FALL TEAM 更新履歴
                       //Victory Fall TEAM- MYAT THADAR LINN||LIAM HTET||SHANTI||PHYO EI LINN
                    
                            //11/26/2025 ~ サウンドプレーヤーとキーボードサポートを追加した更新コード

                              //イデア：ミャッタダリン、シャンティ、ピョーエイリン

                                 //サウンド選び:リアム・ヘット

                                   //メンバー分かりやすくためミャンマー語でコンメント追加しました。



using System;
using System.Windows;
using System.Windows.Controls;
using System.Globalization; 
using System.Linq; 
using System.Windows.Media; // 🔊 Sound Player အတွက်
using System.Windows.Input; // ⌨️ Keyboard Input အတွက်

                            
namespace _6週目_MYAT_THADAR_LINN_Vicroty_Fall
{
    public partial class MainWindow : Window
    {
        // #####################################################################
        // #           အပိုင်း (၁): ကိန်းရှင်များ (Variables)                       #
        // #####################################################################

        private decimal firstNumber = 0;
        private string operation = string.Empty;
        private bool isNewNumber = true;
        private decimal memoryValue = 0;
        private bool isBurmeseMode = false;

        // 🔊 Sound Player  (အသစ်ထည့်သွင်း)
        private readonly MediaPlayer soundPlayer = new MediaPlayer();

        public MainWindow()
        {
            InitializeComponent();
            InitializeSoundPlayer(); // Sound Player Setup (အသစ်ထည့်သွင်း)
            AttachNumberButtons();
            AttachOperatorButtons();
            UpdateModeUI();
        }

        // #####################################################################
        // #           အပိုင်း (၁.၅): Sound Player Logic (အသစ်)      #
        // #####################################################################

        private void InitializeSoundPlayer()
        {
            try
            {
                // Bubble Button Sound ဖိုင်
                soundPlayer.Open(new Uri("click_final.wav", UriKind.Relative));
                soundPlayer.Volume = 1.5; // အသံ အကျယ်အဝန်း 
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error loading sound file: {ex.Message}");
            }
        }

        private void PlayKeyClickSound()
        {
            if (soundPlayer.Source != null)
            {
                soundPlayer.Stop();
                soundPlayer.Play();
            }
        }

        // #####################################################################
        // #           အပိုင်း (၂): Helper Methods: ပြောင်း          #
        // #####################################################################

        // ... (ConvertToEnglishDigits, ConvertToBurmeseDigits, UpdateModeUI မူရင်းအတိုင်း) ...

        private string ConvertToEnglishDigits(string text)
        {
            text = text.Replace('၀', '0').Replace('၁', '1').Replace('၂', '2').Replace('၃', '3').Replace('၄', '4')
                         .Replace('၅', '5').Replace('၆', '6').Replace('၇', '7').Replace('၈', '8').Replace('၉', '9')
                         .Replace("ဒသမ", ".");
            return text;
        }

        private string ConvertToBurmeseDigits(string text)
        {
            text = text.Replace('0', '၀').Replace('1', '၁').Replace('2', '၂').Replace('3', '၃').Replace('4', '၄')
                         .Replace('5', '၅').Replace('6', '၆').Replace('7', '၇').Replace('8', '၈').Replace('9', '၉');
            text = text.Replace(".", "ဒသမ");
            return text;
        }

        private void UpdateModeUI()
        {
            string currentDisplay = ConvertToEnglishDigits(DisplayTextBlock.Text);

            if (isBurmeseMode)
            {
                ModeTextBlock.Text = "မုဒ်: မြန်မာ";
                Btn0.Content = "၀"; Btn1.Content = "၁"; Btn2.Content = "၂";
                Btn3.Content = "၃"; Btn4.Content = "၄"; Btn5.Content = "၅";
                Btn6.Content = "၆"; Btn7.Content = "၇"; Btn8.Content = "၈";
                Btn9.Content = "၉";
                BtnAC.Content = "ရှင်း"; BtnDEL.Content = "ဖြုတ်";
                BtnDecimal.Content = "ဒသမ";
                BtnEqual.Content = "ညီမျှ";
                BtnMC.Content = "Mရ"; BtnMR.Content = "Mခေါ်";

                DisplayTextBlock.Text = ConvertToBurmeseDigits(currentDisplay);
            }
            else
            {
                ModeTextBlock.Text = "Mode: English";
                Btn0.Content = "0"; Btn1.Content = "1"; Btn2.Content = "2";
                Btn3.Content = "3"; Btn4.Content = "4"; Btn5.Content = "5";
                Btn6.Content = "6"; Btn7.Content = "7"; Btn8.Content = "8";
                Btn9.Content = "9";
                BtnAC.Content = "AC"; BtnDEL.Content = "DEL";
                BtnDecimal.Content = ".";
                BtnEqual.Content = "=";
                BtnMC.Content = "MC"; BtnMR.Content = "MR";

                DisplayTextBlock.Text = currentDisplay;
            }
        }

        // #####################################################################
        // #           အပိုင်း (၃): ခလုတ် Event များ ချိတ်ဆက်                #
        // #####################################################################

        // ... (AttachNumberButtons, AttachOperatorButtons မူရင်းအတိုင်း) ...

        private void AttachNumberButtons()
        {
            Btn0.Click += NumberButton_Click; Btn1.Click += NumberButton_Click;
            Btn2.Click += NumberButton_Click; Btn3.Click += NumberButton_Click;
            Btn4.Click += NumberButton_Click; Btn5.Click += NumberButton_Click;
            Btn6.Click += NumberButton_Click; Btn7.Click += NumberButton_Click;
            Btn8.Click += NumberButton_Click; Btn9.Click += NumberButton_Click;
            BtnDecimal.Click += NumberButton_Click;
        }

        private void AttachOperatorButtons()
        {
            BtnAdd.Click += OperatorButton_Click;
            BtnSubtract.Click += OperatorButton_Click;
            BtnMultiply.Click += OperatorButton_Click;
            BtnDivide.Click += OperatorButton_Click;
            BtnPercent.Click += OperatorButton_Click;

            BtnAC.Click += BtnAC_Click;
            BtnDEL.Click += BtnDEL_Click;
            BtnEqual.Click += BtnEqual_Click;
            BtnMC.Click += BtnMC_Click;
            BtnMR.Click += BtnMR_Click;
            BtnMPlus.Click += BtnMPlus_Click;
            BtnMMinus.Click += BtnMMinus_Click;

            BtnGlobe.Click += BtnGlobe_Click;
        }

        // #####################################################################
        // #           အပိုင်း (၄): Helper Logic Methods (Bugs ပြင်)          #
        // #####################################################################

        private decimal PerformCalculation(decimal secondNumber, string currentOperation)
        {
            decimal result = 0;

            switch (currentOperation)
            {
                case "+": result = firstNumber + secondNumber; break;
                case "-": result = firstNumber - secondNumber; break;
                case "X": result = firstNumber * secondNumber; break;
                case "÷":
                    if (secondNumber == 0) throw new DivideByZeroException(); // Divide by Zero စစ်ဆေးခြင်း
                    result = firstNumber / secondNumber;
                    break;
                case "%":
                    // % တွက်ချက်မှု Logic ကို ပြန်လည်ပြင်ဆင်ထား
                    result = (secondNumber / 100);
                    break;
            }
            return result;
        }

        private void UpdateDisplayWithResult(decimal result)
        {
            string resultString = Math.Round(result, 10).ToString(CultureInfo.InvariantCulture);
            DisplayTextBlock.Text = isBurmeseMode ? ConvertToBurmeseDigits(resultString) : resultString;
        }

        // #####################################################################
        // #           : ဂဏန်းနှင့် Operator Logic (Core Logic)          #
        // #####################################################################

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); //

            string newDigitContent = ((Button)sender).Content.ToString();

            if (isNewNumber)
            {
                DisplayTextBlock.Text = "";
                isNewNumber = false;
            }

            if (newDigitContent == "." || newDigitContent == "ဒသမ")
            {
                if (!DisplayTextBlock.Text.Contains(".") && !DisplayTextBlock.Text.Contains("ဒသမ"))
                {
                    DisplayTextBlock.Text += isBurmeseMode ? "ဒသမ" : ".";
                }
            }
            else
            {
                DisplayTextBlock.Text += newDigitContent;
            }
        }

        private void OperatorButton_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // sound play function call

            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);

            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
            {
                string newOperation = ((Button)sender).Content.ToString();

                if (!string.IsNullOrEmpty(operation) && !isNewNumber)
                {
                    try
                    {
                        decimal result = PerformCalculation(currentNumber, operation);
                        UpdateDisplayWithResult(result);
                        firstNumber = result;
                    }
                    catch (DivideByZeroException)
                    {
                        DisplayTextBlock.Text = "Error: Div by zero";
                        firstNumber = 0;
                        operation = string.Empty;
                        isNewNumber = true;
                        return;
                    }
                }
                else if (string.IsNullOrEmpty(operation))
                {
                    firstNumber = currentNumber;
                }

                operation = newOperation;
                isNewNumber = true;
            }
        }

        // #####################################################################
        // #           အပိုင်း (၅): အထူးလုပ်ဆောင်ချက်များ (Special Functions)        #
        // #####################################################################

        private void BtnAC_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 🔊
            firstNumber = 0;
            operation = string.Empty;
            isNewNumber = true;
            DisplayTextBlock.Text = isBurmeseMode ? "၀" : "0";
        }

        private void BtnDEL_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            if (DisplayTextBlock.Text.Length > 1)
            {
                DisplayTextBlock.Text = DisplayTextBlock.Text.Substring(0, DisplayTextBlock.Text.Length - 1);
            }
            else
            {
                DisplayTextBlock.Text = isBurmeseMode ? "၀" : "0";
                isNewNumber = true; // Delete လုပ်ပြီး 0 ကျန်ရင် နောက်ဂဏန်းကို အစားထိုးနိုင်စေရန်
            }
        }

        private void BtnEqual_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            if (operation == string.Empty) return;

            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
            string previousOperation = operation;

            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal secondNumber))
            {
                try
                {
                    decimal result = PerformCalculation(secondNumber, previousOperation);
                    UpdateDisplayWithResult(result);
                    firstNumber = result;
                    operation = string.Empty;
                    isNewNumber = true;
                }
                catch (DivideByZeroException)
                {
                    DisplayTextBlock.Text = "Error: Div by zero";
                    firstNumber = 0;
                    operation = string.Empty;
                    isNewNumber = true;
                }
            }
        }

        // #####################################################################
        // #           အပိုင်း (၆): Memory Logic (M Functions) / Globe              #
        // #####################################################################

        private void BtnMC_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            memoryValue = 0;
            isNewNumber = true;
        }

        private void BtnMR_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            string memoryString = memoryValue.ToString(CultureInfo.InvariantCulture);
            DisplayTextBlock.Text = isBurmeseMode ? ConvertToBurmeseDigits(memoryString) : memoryString;
            isNewNumber = true;
        }

        private void BtnMPlus_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
            {
                memoryValue += currentNumber;
                isNewNumber = true;
            }
        }

        private void BtnMMinus_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            string displayValue = ConvertToEnglishDigits(DisplayTextBlock.Text);
            if (decimal.TryParse(displayValue, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal currentNumber))
            {
                memoryValue -= currentNumber;
                isNewNumber = true;
            }
        }

        private void BtnGlobe_Click(object sender, RoutedEventArgs e)
        {
            PlayKeyClickSound(); // 
            isBurmeseMode = !isBurmeseMode;
            UpdateModeUI();
        }

        // #####################################################################
        // #           အပိုင်း (၇): ကီးဘုတ်  (Keyboard Support)          #
        // #####################################################################

        // Helper function: ကီးဘုတ် input ကို Button Click လို သတ်မှတ်ပေးသည်
        private void SimulateButtonClick(string content)
        {
            // PlayKeyClickSound() ကို Window_KeyDown ထဲမှာ ခေါ်ပြီးသားဖြစ်လို့ ဒီမှာ ထပ်မခေါ်ပါ

            if (content.All(char.IsDigit) || content == "." || content == "ဒသမ")
            {
                // ဂဏန်း သို့မဟုတ် ဒသမ ဖြစ်လျှင်
                Button tempButton = new Button { Content = content };
                NumberButton_Click(tempButton, new RoutedEventArgs());
            }
            else if (content == "+" || content == "-" || content == "X" || content == "÷" || content == "%")
            {
                // Operator ဖြစ်လျှင်
                Button tempButton = new Button { Content = content };
                OperatorButton_Click(tempButton, new RoutedEventArgs());
            }
        }

        private void Window_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            PlayKeyClickSound(); // 🔊 Keyboard နှိပ်တိုင်း အသံထွက်

            string keyChar = string.Empty;

            if (e.Key >= Key.D0 && e.Key <= Key.D9) // Main Keyboard Row 0-9
            {
                keyChar = (e.Key - Key.D0).ToString();
            }
            else if (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) // Numeric Keypad 0-9
            {
                keyChar = (e.Key - Key.NumPad0).ToString();
            }
            else
            {
                switch (e.Key)
                {
                    case Key.OemPeriod:
                    case Key.Decimal:
                        keyChar = isBurmeseMode ? "ဒသမ" : ".";
                        break;
                    case Key.Add:
                    case Key.OemPlus:
                        keyChar = "+";
                        break;
                    case Key.Subtract:
                    case Key.OemMinus:
                        keyChar = "-";
                        break;
                    case Key.Multiply:
                        keyChar = "X";
                        break;
                    case Key.Divide:
                    case Key.OemQuestion:
                        keyChar = "÷";
                        break;
                    case Key.P: // Percent အတွက်
                        keyChar = "%";
                        break;
                    case Key.Enter: // Equal
                        BtnEqual_Click(null, null);
                        return;
                    case Key.Back: // DEL
                        BtnDEL_Click(null, null);
                        return;
                    case Key.Escape: // AC/Clear
                        BtnAC_Click(null, null);
                        return;
                    default:
                        return;
                }
            }

            if (!string.IsNullOrEmpty(keyChar))
            {
                SimulateButtonClick(keyChar);
            }
        }
    }
}