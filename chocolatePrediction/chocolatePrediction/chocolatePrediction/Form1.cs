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
        private string specificBeanOrigin;
        private string refVal;
        private string reviewDate;
        private string cocoaPercent;
        private string companyLocation;
        private string beanType;
        private string broadBeanOrigin;
        private string rating = "3.75";

        private async void btn_predict_Click(object sender, EventArgs e)
        {
            //dohvaćanje podataka iz textBoxova
            company = txtCompany.Text.ToString();
            specificBeanOrigin = txtSpecificBeanOrigin.Text.ToString();
            refVal = txtRef.Text.ToString();
            reviewDate = txtReviewDate.Text.ToString();
            cocoaPercent = txtCocoaPercent.Text.ToString();
            companyLocation = txtCompanyLocation.Text.ToString();
            beanType = txtBeanType.Text.ToString();
            broadBeanOrigin = txtBroadBeanOrigin.Text.ToString();


            //čupanje podataka
            using (var client = new HttpClient())
            {
                var scoreRequest = new
                {
                    Inputs = new Dictionary<string, List<Dictionary<string, string>>>() {
                        {
                            "input1",
                            new List<Dictionary<string, string>>(){new Dictionary<string, string>(){
                                            {
                                                "Company", company.ToString()
                                            },
                                            {
                                                "Specific Bean Origin", specificBeanOrigin.ToString()
                                            },
                                            {
                                                "REF", refVal.ToString()
                                            },
                                            {
                                                "Review Date", reviewDate.ToString()
                                            },
                                            {
                                                "Cocoa Percent", cocoaPercent.ToString()
                                            },
                                            {
                                                "Company Location", company.ToString()
                                            },
                                            {
                                                "Rating", "1"
                                            },
                                            {
                                                "Bean Type", beanType.ToString()
                                            },
                                            {
                                                "Broad Bean Origin", broadBeanOrigin.ToString()
                                            },
                                }
                            }
                        },
                    },
                    GlobalParameters = new Dictionary<string, string>()
                    {
                    }
                };

                const string apiKey = "/m1nW7l9pUi8kUEui4cYyBH46bOUbESRYApCKecUSp4ES/WTLF7n3G+u5nkRurQMpZ8+r+Dd7/D2CE+r1P7blg=="; // Replace this with the API key for the web service
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiKey);
                client.BaseAddress = new Uri("https://ussouthcentral.services.azureml.net/workspaces/444fb7db90244e75a78e014b22cfd457/services/fdd47fb1f38f424d952e8943004b7edb/execute?api-version=2.0&format=swagger");

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    getChocolateClass(result);
                }
                else
                {
                    Console.WriteLine(string.Format("The request failed with status code: {0}", response.StatusCode));

                    // Print the headers - they include the requert ID and the timestamp,
                    // which are useful for debugging the failure
                    Console.WriteLine(response.Headers.ToString());

                    string responseContent = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(responseContent);
                }
            }
        }

        private void getChocolateClass(string result)
        {
            //parsanje responsa
            string[] resultArray;
            double[] classPercentage = new double[2];

            resultArray = result.Split('\\');

            //prvaKlasa
            resultArray[2] = resultArray[2].Replace(":", "");
            resultArray[2] = resultArray[2].Replace(",", "");
            resultArray[2] = resultArray[2].Replace("Scored Probabilities for Class ", "");
            resultArray[2] = resultArray[2].Replace("\"", "");

            //drugaKlasa
            resultArray[4] = resultArray[4].Replace(":", "");
            resultArray[4] = resultArray[4].Replace(",", "");
            resultArray[4] = resultArray[4].Replace("Scored Probabilities for Class ", "");
            resultArray[4] = resultArray[4].Replace("\"", "");

            //trecaKlasa
            resultArray[6] = resultArray[6].Replace(":", "");
            resultArray[6] = resultArray[6].Replace(",", "");
            resultArray[6] = resultArray[6].Replace("Scored Labels", "");
            resultArray[6] = resultArray[6].Replace("\"", "");
            resultArray[6] = resultArray[6].Replace("]", "");
            resultArray[6] = resultArray[6].Replace("}", "");

            //classPercentage[0] = double.Parse(resultArray[2]);
            //classPercentage[1] = double.Parse(resultArray[4]);
            //classPercentage[2] = double.Parse(resultArray[6]);



            if (resultArray[2] == "0.51*" || resultArray[2] == "0.61*" || resultArray[2] == "0.71*" || resultArray[2] == "0.81*" || resultArray[2] == "0.91*" || resultArray[2] == "1")
                MessageBox.Show("It's excelet chocolate with percentage of " + resultArray[2], "Result", MessageBoxButtons.OK);
            else if (resultArray[4] == "0.51*" || resultArray[4] == "0.61*" || resultArray[4] == "0.71*" || resultArray[4] == "0.81*" || resultArray[4] == "0.91*" || resultArray[4] == "1")
                MessageBox.Show("It's good chocolate with percentage of " + resultArray[4], "Result", MessageBoxButtons.OK);
            else if (resultArray[6] == "0.51*" || resultArray[6] == "0.61*" || resultArray[6] == "0.71*" || resultArray[6] == "0.81*" || resultArray[6] == "0.91*" || resultArray[6] == "1")
                MessageBox.Show("It's bad chocolate with percentage of " + resultArray[6], "Result", MessageBoxButtons.OK);

            //MessageBox.Show(classPercentage[0].ToString(), "Result A", MessageBoxButtons.OK);

            //Console.WriteLine("Result: {0}", result);
            //MessageBox.Show(result, "Result", MessageBoxButtons.OK);
        }
    }
}
