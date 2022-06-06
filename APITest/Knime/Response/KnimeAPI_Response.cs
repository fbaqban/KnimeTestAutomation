using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITest.Knime.Response
{

    public class GetKnimeResponse
    {
        public string id { get; set; }
        public string type { get; set; }
        public string path { get; set; }
        public string _class { get; set; }
        public string owner { get; set; }
        public string author { get; set; }
        public DateTime createdOn { get; set; }
        public int downloadCount { get; set; }
        public Child[] children { get; set; }
        public Controls controls { get; set; }
        public Namespaces namespaces { get; set; }
    }

    public class Controls
    {
        public Self self { get; set; }
        public KnimeDownload knimedownload { get; set; }
        public Edit edit { get; set; }
        public KnimeUpload knimeupload { get; set; }
        public KnimeCreate knimecreate { get; set; }
    }

    public class Self
    {
        public string href { get; set; }
        public string method { get; set; }
    }

    public class KnimeDownload
    {
        public string href { get; set; }
        public string method { get; set; }
    }

    public class Edit
    {
        public string href { get; set; }
        public string method { get; set; }
        public string[] accept { get; set; }
        public string encoding { get; set; }
        public string title { get; set; }
    }

    public class KnimeUpload
    {
        public string href { get; set; }
        public bool isHrefTemplate { get; set; }
        public string method { get; set; }
        public string[] accept { get; set; }
        public string encoding { get; set; }
        public string title { get; set; }
    }

    public class KnimeCreate
    {
        public string href { get; set; }
        public bool isHrefTemplate { get; set; }
        public string method { get; set; }
        public string[] accept { get; set; }
        public string encoding { get; set; }
        public string title { get; set; }
    }

    public class Namespaces
    {
        public Knime knime { get; set; }
    }

    public class Knime
    {
        public string name { get; set; }
    }

    public class Child
    {
        public string id { get; set; }
        public string type { get; set; }
        public string path { get; set; }
        public string _class { get; set; }
        public string owner { get; set; }
        public string author { get; set; }
        public DateTime createdOn { get; set; }
        public string description { get; set; }
        public int downloadCount { get; set; }
        public int kudosCount { get; set; }
        public DateTime lastEditedOn { get; set; }
        public bool _private { get; set; }
        public object[] tags { get; set; }
        public object[] contributors { get; set; }
        public object[] accesses { get; set; }
        public object[] kudos { get; set; }
        public Stats stats { get; set; }
    }

    public class Stats
    {
        public int workflows { get; set; }
        public int components { get; set; }
        public int dataFiles { get; set; }
    }


}

