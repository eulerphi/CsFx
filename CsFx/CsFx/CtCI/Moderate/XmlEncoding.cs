using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CsFx.CtCI.Moderate {
    class XmlEncoding {
        private static Lazy<IDictionary<string, string>> mappings =
            new Lazy<IDictionary<string, string>>(CreateMappings);

        public static string Encode(XElement root) {
            if (root == null) {
                throw new ArgumentNullException();
            }

            return EncodeInternal(root);
        }

        private static string EncodeInternal(XElement root) {
            var builder = new StringBuilder();
            builder.Append(mappings.Value[root.Name.LocalName]);

            foreach (var attr in root.Attributes()) {
                builder.Append(" " + mappings.Value[attr.Name.LocalName]);
                builder.Append(" " + attr.Value);
            }

            if (root.Attributes().Any()) {
                builder.Append(" 0");
            }

            var children = root.Elements();
            if (!children.Any() && !String.IsNullOrEmpty(root.Value)) {
                builder.Append(" " + root.Value);
            }

            foreach (var child in children) {
                builder.Append(" " + EncodeInternal(child));
            }

            builder.Append(" 0");

            return builder.ToString();
        }

        private static IDictionary<string, string> CreateMappings() {
            var mappings = new Dictionary<string, string>();
            mappings["family"] = "1";
            mappings["person"] = "2";
            mappings["firstName"] = "3";
            mappings["lastName"] = "4";
            mappings["state"] = "5";
            return mappings;
        }
    }
}
