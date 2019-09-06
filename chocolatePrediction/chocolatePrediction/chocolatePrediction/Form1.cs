using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using Newtonsoft.Json.Linq;

namespace chocolatePrediction
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //deklaracija svih potrebnih varijabli
        private string company;
        private string cocoaPercent;
        private string beanType;

        private async void btn_predict_Click(object sender, EventArgs e)
        {
            //dohvaćanje podataka iz textBoxova
            company = txtCompany.Text.ToString();
            cocoaPercent = txtCocoaPercent.Text.ToString();
            beanType = txtBeanType.Text.ToString();


            //čupanje podataka
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input_parameters",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Company", company.ToString()
                                            },
                                            {
                                                "Cocoa Percent", cocoaPercent.ToString()
                                            },
                                            {
                                                "Bean Type", beanType.ToString()
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string apiKey = "k88Winhn2VUz75HswnfsP35RJ2bz8sphInzJxbqFXcgqyL0I62CmhbX8qkE92dl9TWIZR23oJ5/KrgbMfNAa8w=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/444fb7db90244e75a78e014b22cfd457/services/9237b3560e5744549c7cc067bb985e7f/execute?api-version=2.0&format=swagger");

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    getChocolateClass(result);
                }
                else
                {
                    string responseContent = await response.Content.ReadAsStringAsync();
                    MessageBox.Show("The request failed with status code: {0}" + response.StatusCode, "Error", MessageBoxButtons.OK);
                }
            }
        }

        private void getChocolateClass(string result)
        {
            //parsanje responsa

            string[] resultArray, badClassArray, goodClassArray, excelentClassArray;
            Decimal bad, good, excelent;

            resultArray = result.Split(',');
            badClassArray = resultArray[4].Split(':');
            goodClassArray = resultArray[5].Split(':');
            excelentClassArray = resultArray[6].Split(':');

            bad = Convert.ToDecimal(Double.Parse(badClassArray[1].Replace("\"", ""), NumberStyles.Float, CultureInfo.InvariantCulture));
            good = Convert.ToDecimal(Double.Parse(goodClassArray[1].Replace("\"", ""), NumberStyles.Float, CultureInfo.InvariantCulture));
            excelent = Convert.ToDecimal(Double.Parse(excelentClassArray[1].Replace("\"", ""), NumberStyles.Float, CultureInfo.InvariantCulture));

            //MessageBox.Show(result, "Result", MessageBoxButtons.OK);

            if (bad > good && bad > excelent)
                MessageBox.Show("It's bad chocolate with percentage of " + bad.ToString(), "Result", MessageBoxButtons.OK);
            else if (good > bad && good > excelent)
                MessageBox.Show("It's good chocolate with percentage of " + good.ToString(), "Result", MessageBoxButtons.OK);
            else if (excelent > bad && excelent > good)
                MessageBox.Show("It's excelet chocolate with percentage of " + excelent.ToString(), "Result", MessageBoxButtons.OK);

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void txtBroadBeanOrigin_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void txtBeanType_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
