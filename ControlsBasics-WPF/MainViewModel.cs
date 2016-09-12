using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Microsoft.Samples.Kinect.ControlsBasics
{
    public class MainViewModel 
    {
        public MainModel mainModel { get; set; }
        private XmlNodeList recommmendations;

        public MainViewModel()
        {
            //This data will load as the default person from the model attached to
            //the view 
            mainModel = new MainModel { RecommendationCode = 1, Recommendation = "Noir" };
        }
        //} 
        private string _Recommendation;
        public string Recommendation
        {
            get
            { return _Recommendation; }
            set
            {
                _Recommendation = String.Format("Random Recommendation: \n{0}", value); ;
            }
        }
        public void UpdateRecommendation()
        {
            if (recommmendations == null)
                loadXML();

            int MaxCount = recommmendations.Count;


            int randNumber = new Random().Next(1, MaxCount);
            //var recommendation = recommmendations.Cast<XmlNode>().Select(x=> x.InnerText==randNumber.ToString()).FirstOrDefault();

            foreach (XmlNode recommendation in recommmendations)
            {
                if (recommendation.FirstChild.InnerText == randNumber.ToString())
                {
                    //txtRecommendation.Text = recommendation.LastChild.InnerText;
                    this.Recommendation = recommendation.LastChild.InnerText;
                    break;
                }
            }
        }
        private void loadXML()
        {
            //String fileName = @"E:\Coles\Wines\ControlsBasics-WPF\Recommendation.xml";
            String fileName = @"Recommendation.xml";
            XmlDocument xml = new XmlDocument();
            xml.Load(fileName);
            recommmendations = xml.SelectNodes("//Recommendation"); // double '/' to get nodes at any level (XPath syntax)
        }

    }
}
