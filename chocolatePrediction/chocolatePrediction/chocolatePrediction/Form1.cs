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
        private string rating = "1";

        public class StringTable
        {
            public string[] columnNames { get; set; }
            public string[,] values { get; set; }
        }

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

                    Inputs = new Dictionary<string, StringTable>() {
                        {
                            "input1",
                            new StringTable()
                            {
                                columnNames = new string[] { "Company", "Specific Bean Origin", "REF", "Review Date", "Cocoa Percent", "Company Location", "Rating", "Bean Type", "Broad Bean Origin" },
                                values = new string[,] { { company, specificBeanOrigin, refVal, reviewDate, cocoaPercent, companyLocation, rating, beanType, broadBeanOrigin } }

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

                // WARNING: The 'await' statement below can result in a deadlock
                // if you are calling this code from the UI thread of an ASP.Net application.
                // One way to address this would be to call ConfigureAwait(false)
                // so that the execution does not attempt to resume on the original context.
                // For instance, replace code such as:
                //      result = await DoSomeTask()
                // with the following:
                //      result = await DoSomeTask().ConfigureAwait(false)

                HttpResponseMessage response = await client.PostAsJsonAsync("", scoreRequest);

                if (response.IsSuccessStatusCode)
                {
                    //hilfe
                    string result = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Result: {0}", result);
                    MessageBox.Show(result, "Result", MessageBoxButtons.OK);
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
    }
}
