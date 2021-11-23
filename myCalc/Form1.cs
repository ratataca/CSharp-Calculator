using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


static class Constants
{
    public const int ADD = 1;
    public const int SUBTRACT = 2; 
    public const int MULTIPLY = 3; 
    public const int DIVISION = 4; 
}


namespace myCalc
{
    public partial class Form1 : Form
    {
        double input_num_1 = 0;
        double input_num_2 = 0;
        bool isError = false;
        int type = 0;
        
        public Form1()
        {
            InitializeComponent();

            num_1.Click += num_0_Click;
            num_2.Click += num_0_Click;
            num_3.Click += num_0_Click;
            num_4.Click += num_0_Click;
            num_5.Click += num_0_Click;
            num_6.Click += num_0_Click;
            num_7.Click += num_0_Click;
            num_8.Click += num_0_Click;
            num_9.Click += num_0_Click;
            
        }
        
        // 숫자 버튼에 대한 이벤트
        private void num_0_Click(object sender, EventArgs e)
        {
            Button self = (Button)sender;
            if (isError == true)
            {
                text_result.Text = "";
                isError = false;
            }
            text_result.Text += self.Text;
            
        }

        // Clear 버튼에 대한 이벤트
        private void button15_Click(object sender, EventArgs e)
        {
            text_result.Text = "";
            type = 0;

        }

        private void add_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                type = Constants.ADD;
                text_result.Text += "+";
            }
            else {
                text_result.Text = "수식이 잘못되었습니다.";
                isError = true;
            }
        }

        private void subtract_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                type = Constants.SUBTRACT;
                text_result.Text += "-";
            }
            else
            {
                text_result.Text = "수식이 잘못되었습니다.";
                isError = true;
            }
        }

        private void multiply_Click(object sender, EventArgs e)
        {
            
            if (type == 0)
            {
                type = Constants.MULTIPLY;
                text_result.Text += "*";
            }
            else
            {
                text_result.Text = "수식이 잘못되었습니다.";
                isError = true;
            }
        }

        private void division_Click(object sender, EventArgs e)
        {
            if (type == 0)
            {
                type = Constants.DIVISION;
                text_result.Text += "/";
            }
            else
            {
                text_result.Text = "수식이 잘못되었습니다.";
                isError = true;
            }
        }
      
        private void equal_Click(object sender, EventArgs e)
        {
            double result = 0.0;

            if (text_result.Text == "수식이 잘못되었습니다.") {
                isError = true;
                type = 0;
                return;
            }

            switch (type) {
                case Constants.ADD:
                    String[] subsAdd = text_result.Text.Split("+");

                    if (subsAdd[1] != "" )
                    {
                        input_num_1 = double.Parse(subsAdd[0]);
                        input_num_2 = double.Parse(subsAdd[1]);

                        result = input_num_1 + input_num_2;
                        text_result.Text = result.ToString();
                    }
                    else {
                        text_result.Text = "수식이 잘못되었습니다.";
                        isError = true;
                        type = 0;
                        return;
                    }                    
                    break;

                case Constants.SUBTRACT:
                    String[] subsSub = text_result.Text.Split("-");

                    if (subsSub[1] != "")
                    {
                        input_num_1 = double.Parse(subsSub[0]);
                        input_num_2 = double.Parse(subsSub[1]);

                        result = input_num_1 - input_num_2;
                        text_result.Text = result.ToString();
                    }
                    else
                    {
                        text_result.Text = "수식이 잘못되었습니다.";
                        isError = true;
                        type = 0;
                        return;
                    }                   
                    break;

                case Constants.MULTIPLY:
                    String[] subsMul = text_result.Text.Split("*");

                    if (subsMul[1] != "")
                    {
                        input_num_1 = double.Parse(subsMul[0]);
                        input_num_2 = double.Parse(subsMul[1]);

                        result = input_num_1 * input_num_2;
                        text_result.Text = result.ToString();
                    }
                    else
                    {
                        text_result.Text = "수식이 잘못되었습니다.";
                        isError = true;
                        type = 0;
                        return;
                    }
                    break;

                case Constants.DIVISION:
                    String[] subsDiv = text_result.Text.Split("/");

                    if (subsDiv[1] != "")
                    {
                        input_num_1 = double.Parse(subsDiv[0]);
                        input_num_2 = double.Parse(subsDiv[1]);

                        result = input_num_1 / input_num_2;
                        text_result.Text = result.ToString();
                    }
                    else
                    {
                        text_result.Text = "수식이 잘못되었습니다.";
                        isError = true;
                        type = 0;
                        return;
                    }
                    break;

                default:
                    text_result.Text = "선택된 연산자가 없습니다.";
                    isError = true;
                    type = 0;
                    break;
            }
            
            type = 0;
        }       
    }
}
