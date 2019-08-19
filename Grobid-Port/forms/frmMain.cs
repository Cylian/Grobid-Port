using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp2
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        private string config_path = "./app.config";
        private XElement app_config = null;
        private void read_config(string file_path)
        {
            XElement xe = XElement.Parse("<api_details for=\"GROBID\"><api_detail display_text=\"Annotate PDF\" name=\"/api/annotatePDF\" method_name=\"POST\" request_type=\"multipart/form-data\" response_type=\"application/pdf\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"PDF file to be processed\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate and inject DOI only)\"/></parameters></api_detail><api_detail display_text=\"Citation Patent Annotations\" name=\"/api/citationPatentAnnotations\" method_name=\"POST\" request_type=\"multipart/form-data\" response_type=\"application/json\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"Patent publication PDF file to be processed, returned coordinates will reference this PDF\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate and inject DOI only)\"/></parameters></api_detail><api_detail display_text=\"Process Affiliations\" name=\"/api/processAffiliations\" method_name=\"POST, PUT\" request_type=\"application/x-www-form-urlencoded\" response_type=\"application/xml\"><parameters><parameter name=\"affiliations\" required=\"yes\" default=\"n/a\" description=\"sequence of affiliations+addresses to be parsed as raw string\"/></parameters></api_detail><api_detail display_text=\"Process Citation\" name=\"/api/processCitation\" method_name=\"POST, PUT\" request_type=\"application/x-www-form-urlencoded\" response_type=\"application/xml\"><parameters><parameter name=\"citations\" required=\"yes\" default=\"n/a\" description=\"bibliographical reference to be parsed as raw string\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate the citation and inject DOI only)\"/></parameters></api_detail><api_detail display_text=\"Process Citation Names\" name=\"/api/processCitationNames\" method_name=\"POST, PUT\" request_type=\"application/x-www-form-urlencoded\" response_type=\"application/xml\"><parameters><parameter name=\"names\" required=\"yes\" default=\"n/a\" description=\"sequence of names to be parsed as raw string\"/></parameters></api_detail><api_detail display_text=\"Process Citation Patent PDF\" name=\"/api/processCitationPatentPDF\" method_name=\"POST, PUT\" request_type=\"multipart/form-data\" response_type=\"application/xml\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"PDF file of the patent document to be processed\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate and inject DOI only)\"/></parameters></api_detail><api_detail display_text=\"Process Citation Patent ST36\" name=\"/api/processCitationPatentST36\" method_name=\"POST, PUT\" request_type=\"multipart/form-data\" response_type=\"application/xml\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"XML file in ST36 standard of the patent document to be processed\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate and inject DOI only)\"/></parameters></api_detail><api_detail display_text=\"Process Citation Patent TXT\" name=\"/api/processCitationPatentTXT\" method_name=\"POST, PUT\" request_type=\"application/x-www-form-urlencoded\" response_type=\"application/xml\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"patent text to be processed as raw string\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate and inject DOI only)\"/></parameters></api_detail><api_detail display_text=\"Process Date\" name=\"/api/processDate\" method_name=\"POST, PUT\" request_type=\"application/x-www-form-urlencoded\" response_type=\"application/xml\"><parameters><parameter name=\"date\" required=\"yes\" default=\"n/a\" description=\"date to be parsed as raw string\"/></parameters></api_detail><api_detail display_text=\"Process Fulltext Document\" name=\"/api/processFulltextDocument\" method_name=\"POST, PUT\" request_type=\"multipart/form-data\" response_type=\"application/xml\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"PDF file to be processed\"/><parameter name=\"consolidateHeader\" required=\"no\" default=\"1\" description=\"consolidateHeader is a string of value 0 (no consolidation) or 1 (consolidate and inject all extra metadata, default value), or 2 (consolidate and inject only the DOI value).\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate and inject all extra metadata), or 2 (consolidate and inject only the DOI value).\"/><parameter name=\"teiCoordinates\" required=\"no\" default=\"---\" description=\"list of element names for which coordinates in the PDF document have to be added, see Coordinates of structures in the original PDF for more details\"/></parameters></api_detail><api_detail display_text=\"Process Header Document\" name=\"/api/processHeaderDocument\" method_name=\"POST, PUT\" request_type=\"multipart/form-data\" response_type=\"application/xml\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"PDF file to be processed\"/><parameter name=\"consolidateHeader\" required=\"no\" default=\"1\" description=\"consolidateHeader is a string of value 0 (no consolidation) or 1 (consolidate and inject all extra metadata, default value), or 2 (consolidate and inject only the DOI value).\"/></parameters></api_detail><api_detail display_text=\"Process Header Names\" name=\"/api/processHeaderNames\" method_name=\"POST, PUT\" request_type=\"application/x-www-form-urlencoded\" response_type=\"application/xml\"><parameters><parameter name=\"names\" required=\"yes\" default=\"n/a\" description=\"sequence of names to be parsed as raw string\"/></parameters></api_detail><api_detail display_text=\"Process References\" name=\"/api/processReferences\" method_name=\"POST, PUT\" request_type=\"multipart/form-data\" response_type=\"application/xml\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"PDF file to be processed\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate all found bib. ref. and inject all extra metadata), or 2 (consolidate all found bib. ref. and inject only the DOI value).\"/></parameters></api_detail><api_detail display_text=\"Reference Annotations\" name=\"/api/referenceAnnotations\" method_name=\"POST\" request_type=\"multipart/form-data\" response_type=\"application/json\"><parameters><parameter name=\"input\" required=\"yes\" default=\"n/a\" description=\"PDF file to be processed, returned coordinates will reference this PDF\"/><parameter name=\"consolidateCitations\" required=\"no\" default=\"0\" description=\"consolidateCitations is a string of value 0 (no consolidation, default value) or 1 (consolidate the citation and inject extra metadata) or 2 (consolidate and inject DOI only)\"/></parameters></api_detail></api_details>");
            if (File.Exists(file_path))
            {
                this.app_config = XElement.Load(this.config_path);
                //if (XNode.DeepEquals(this.app_config, xe) == false)
                //{

                //}
            }
            else
            {
                this.write_config(this.config_path, xe);
                read_config(file_path);
            }
        }
        private void write_config(string file_path, XElement xe)
        {
            xe.Save(file_path);
        }
        private async void Button1_ClickAsync(object sender, EventArgs e)
        {
            this.Enabled = false;
            try
            {
                //string result = await get_response_from_server("http://localhost:8070/api/processCitation", "citations", txtInput.Text.ToString());
                var keyValues = new List<KeyValuePair<string, string>>();
                var q0 = this.app_config.Descendants("api_detail").Where(c=>c.Attribute("display_text").Value==cmbOptions.Text);
                if (q0.Count() > 0)
                {
                    var q1 = q0.Descendants("parameter"); int counter = 0;
                    foreach (XElement xe in q1)
                    {
                        counter ++;
                        switch (counter)
                        {
                            case 1:
                                keyValues.Add(new KeyValuePair<string, string>(xe.Attribute("name").Value, txtInput.Text.ToString().Replace(@"\","/")));
                                break;
                            default:
                                keyValues.Add(new KeyValuePair<string, string>(xe.Attribute("name").Value, xe.Attribute("default").Value));
                                break;
                        }
                    }
                    var request_type = q0.First().Attribute("request_type").Value;
                    var response_type = q0.First().Attribute("response_type").Value;
                    var result = await get_response_from_server("http://192.168.1.9:8070" + q0.First().Attribute("name").Value, keyValues, request_type);
                    switch (response_type)
                    {
                        case "application/pdf":
                            //pViewer.Visible = true;
                            txtOutput.Visible = false;
                            var out_path = Environment.GetEnvironmentVariable("tmp") + @"\tmp.pdf";
                            File.WriteAllBytes(out_path, Encoding.Default.GetBytes((string)result));
                            //var stream = new FileStream(out_path, FileMode.Open, FileAccess.Read);
                            //var document = PdfiumViewer.PdfDocument.Load(out_path);
                            //pViewer.Renderer.Load(document);
                            //pViewer.f
                            break;
                        case "application/json":
                            //pViewer.Visible = false;
                            txtOutput.Visible = true;
                            txtOutput.Text =(string) result;
                            break;
                        case "application/xml":
                            //pViewer.Visible = false;
                            txtOutput.Visible = true;
                            string out_text = (string)result;
                            out_text = Regex.Replace(Regex.Replace(out_text, @">\s+<", @"><"), "\\s*xmlns=\"[^\"]+\"\\s*", "").Replace("<bibstruct >", "<bibstruct>");
                            out_text = out_text.Replace("><", ">\r\n<");
                            txtOutput.Visible = true;
                            txtOutput.Text = out_text;
                            break;

                    }


                    
                    //XElement xe = XElement.Parse()
                    //if (Regex.IsMatch(textBox1.Text.ToString(), @"[^\r\n]+"))
                    //{

                    //}
                }
            }
            catch (Exception ex1)
            {
                MessageBox.Show(ex1.ToString());
            }
            finally
            {
                this.Enabled = true;
            }

        }
        private async System.Threading.Tasks.Task<string> get_response_from_server(string url_text, string param_name, string param_value)
        {
            string result = null;
            try
            {
                using (var client = new HttpClient()) {
                    var requestContent = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>(param_name, param_value), });
                    HttpResponseMessage response = await client.PostAsync(url_text, requestContent);
                    HttpContent responseContent = response.Content;
                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        result = await reader.ReadToEndAsync();
                    }
                }
            }
            catch{;}
            return result;
        }
        private async System.Threading.Tasks.Task<string> get_response_from_server(string url_text, List<KeyValuePair<string, string>> params_details, string request_type)
        {
            var result = "";
            try
            {
                using (var client = new HttpClient())
                {
                    
                    switch (request_type)
                    {
                        case "multipart/form-data":
                            //var objValues = new List<KeyValuePair<object, object>>();
                            var multipartContent = new MultipartFormDataContent();
                            int counter = 0;
                            foreach (KeyValuePair<string, string> item in params_details)
                            {
                                counter++;
                                switch (counter)
                                {
                                    case 1:
                                        multipartContent.Add(new StreamContent(new MemoryStream( File.ReadAllBytes(item.Value))), item.Key, Path.GetFileName(item.Value));
                                        break;
                                    default:
                                        multipartContent.Add(new StringContent(item.Value), item.Key);
                                        break;
                                }
                            }
                            var multipartRequestContent = multipartContent;
                            HttpResponseMessage multipartResponse = await client.PostAsync(url_text, multipartRequestContent);
                            HttpContent multipartResponseContent = multipartResponse.Content;
                            using (var reader = new StreamReader(await multipartResponseContent.ReadAsStreamAsync()))
                            {
                                result = await reader.ReadToEndAsync();
                            }
                            //var content = multipartRequestContent.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                            break;
                        default:
                            var keyValues = new List<KeyValuePair<string, string>>();
                            foreach (KeyValuePair<string, string> item in params_details)
                            {
                                keyValues.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                            }
                            var requestContent = new FormUrlEncodedContent(keyValues);
                            HttpResponseMessage response = await client.PostAsync(url_text, requestContent);
                            HttpContent responseContent = response.Content;
                            using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                            {
                                result = await reader.ReadToEndAsync();
                            }
                            break;
                    }
                }
            }
            catch {; }
            return result;
        }
        private async System.Threading.Tasks.Task<string> get_response_from_server(string url_text, List<KeyValuePair<string, string>> params_details)
        {
            string result = null;
            try
            {
                using (var client = new HttpClient())
                {
                    var keyValues = new List<KeyValuePair<string, string>>();
                    foreach (KeyValuePair<string, string> item in params_details)
                    {
                        keyValues.Add(new KeyValuePair<string, string>(item.Key, item.Value));
                    }
                    var requestContent = new FormUrlEncodedContent(keyValues);
                    HttpResponseMessage response = await client.PostAsync(url_text, requestContent);
                    HttpContent responseContent = response.Content;
                    using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
                    {
                        result = await reader.ReadToEndAsync();
                    }
                }
            }
            catch {; }
            return result;
        }
        private void TextBox1_LostFocus(object sender, EventArgs e)
        {
            if (txtOutput.Text.ToString().Trim().Length > 0)
            {
                File.WriteAllText("temp.txt", txtOutput.Text.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            read_config(this.config_path);
            load_options();
            txtInput.Text = "A. Cau, R. Kuiper, and W.-P. de Roever. Formalising Dijkstra's development strategy within Stark's formalism. In C. B. Jones, R. C. Shaw, and T. Denvir, editors, Proc. 5th. BCS-FACS Refinement Workshop, 1992.";// Application.ExecutablePath;
        }

        private void generic_checkedChanged(object sender, EventArgs e)
        {
            generic_mouseHover(sender, e);
            CheckBox chk = ((CheckBox)sender); int chk_state = (int)chk.CheckState;
            chk.Tag = chk_state.ToString();
            var q0 = this.app_config.Descendants("api_detail").Where(c=>c.Attribute("display_text").Value==cmbOptions.Text);
            if (q0.Count() > 0)
            {
                var q1 = q0.First().Descendants("parameter");
                foreach(XElement xe in q1)
                {
                    if (xe.Attribute("name").Value.ToLower()== chk.Text.Replace(" ", "").Replace("&", "").ToLower())
                    {
                        xe.Attribute("default").Value = chk_state.ToString();
                        chk.Tag = chk_state.ToString();
                        break;
                    }
                }
                
            }
            
        }

        private void generic_mouseHover(object sender, EventArgs e)
        {
            CheckBox chk = ((CheckBox)sender); int chk_state = (int)chk.CheckState;
            var q0 = this.app_config.Descendants("parameter").Where(c => c.Attribute("name").Value.ToLower() == chk.Text.Replace(" ", "").Replace("&", "").ToLower());
            toolTip1.SetToolTip(chk, q0.First().Attribute("description").Value);
        }
        private void load_options()
        {
            foreach (XElement xe in this.app_config.Descendants("api_detail"))
            {
                cmbOptions.Items.Add(xe.Attribute("display_text").Value);
            }
        }

        private void CmbOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            chkConsolidateCitations.Enabled = false;
            chkConsolidateHeader.Enabled = false;
            chkTEICoordinates.Enabled = false;
            var q0 = this.app_config.Descendants("api_detail").Where(c => c.Attribute("display_text").Value == cmbOptions.Text.ToString());
            if (q0.Count() > 0)
            {
                var q1 = q0.First().Descendants("parameter").Where(c => c.Attribute("required").Value == "no");
                foreach (XElement xe in q1)
                {
                    switch (xe.Attribute("name").Value)
                    {
                        case "consolidateCitations":
                            chkConsolidateCitations.Enabled = true;
                            break;
                        case "consolidateHeader":
                            chkConsolidateHeader.Enabled = true;
                            break;
                        case "teiCoordinates":
                            chkTEICoordinates.Enabled = true;
                            break;
                    }
                }
            }
        }

        private void PdfViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
////"input = " + textBox2.Text.ToString() + "\" http://192.168.1.9:8070/api/processReferences"
////WebRequest request = WebRequest.Create("input=@./temp.txt http://192.168.1.9:8070/api/processReferences");
//WebRequest request = WebRequest.Create("http://192.168.1.9:8070/api/processReferences");
//request.Method = "POST";
//                string postData = textBox1.Text.ToString();
////byte[] byteArray = Encoding.UTF8.GetBytes(postData);
//request.ContentType = "multipart/form-data";

//                //request.ContentLength = byteArray.Length;
//                //Stream dataStream = request.GetRequestStream();
//                //dataStream.Write(byteArray, 0, byteArray.Length);
//                //dataStream.Close();
//                WebResponse response = request.GetResponse();
//string res = ((HttpWebResponse)response).StatusDescription;
////dataStream = response.GetResponseStream();
////StreamReader reader = new StreamReader(dataStream);
////string responseFromServer = reader.ReadToEnd();
//textBox2.Text = res;
//                //reader.Close();
//                //dataStream.Close();
//                response.Close();




//var out_var = "";
//string res = doRequestWithBytesPostData("http://192.168.1.9:8070/api/processReferences", "POST", Encoding.UTF8.GetBytes(textBox2.ToString()), null, "", "", "", "multipart/form-data",out out_var);
//WebClient webClient = new WebClient();
//webClient.Headers.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36");
//                webClient.QueryString.Add("input", textBox2.Text.ToString());
//                //webClient.QueryString.Add("param2", "value2");
//                var response = webClient.DownloadString("http://192.168.1.9:8070/api/processReferences");
//var result = Newtonsoft.Json.Linq.JArray.Parse(response);
//textBox2.Text = "";
//var client = new HttpClient();
//var requestContent = new FormUrlEncodedContent(new[] {new KeyValuePair<string, string>("citations", textBox1.Text.ToString()),});
//HttpResponseMessage response = await client.PostAsync("http://localhost:8070/api/processCitation", requestContent);
//HttpContent responseContent = response.Content;
//using (var reader = new StreamReader(await responseContent.ReadAsStreamAsync()))
//{
//    // Write the output.
//    textBox2.Text = await reader.ReadToEndAsync();
//}
