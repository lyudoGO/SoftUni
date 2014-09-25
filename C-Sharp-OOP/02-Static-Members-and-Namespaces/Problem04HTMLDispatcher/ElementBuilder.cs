using System;
using System.Collections.Generic;

namespace Problem04HTMLDispatcher
{
    class ElementBuilder
    {
        private string element;
        private string content;
        private Dictionary<string, string> attributes = new Dictionary<string, string>();

        public ElementBuilder(string element)
        {
            this.Element = element;
        }

        public string Element
        {
            get { return this.element; }
            set { this.element = value; }
        }

        public override string ToString()
        {
            string atributesStr = "";
            foreach (var item in this.attributes)
            {
                atributesStr += " " + item.Key + "=\"" + item.Value + "\"";
            }

            string result = string.Format("<{0}{1}>{2}</{0}>\n", this.Element, atributesStr, this.content);
            return result;
        }

        public void AddAtribute(string attribute, string value)
        {
            this.attributes.Add(attribute, value);
        }

        public void AddContent(string content)
        {
            this.content = content;
        }

        public static string operator *(ElementBuilder element, int n)
        {
            string result = "";
            for (int i = 0; i < n; i++)
            {
                result += element.ToString();
            }

            return result;
        }
    }
}