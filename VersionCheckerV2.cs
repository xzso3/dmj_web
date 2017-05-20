/*
��Ļ�������� Newtonsoft.Json 7.0.1
����ʹ����ͬ�汾�������ظ����ز�ͬ�汾֮�������

using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

*/

internal class VersionChecker
{
    #region -- ���� --

    /// <summary>
    /// Ĭ�Ϸ�������ַ
    /// </summary>
    public const string DEFAULT_BASE_URL = "https://www.danmuji.cn";

    /// <summary>
    /// API��·��
    /// </summary>
    public const string API_PATH = "/api/v2/";

    /// <summary>
    /// �������ҳ��·��
    /// </summary>
    public const string WEB_PATH = "/plugins/";

    #endregion

    #region -- ���� --
    private string BaseUrl;

    /// <summary>
    /// ���һ�������Exception
    /// </summary>
    public Exception lastException { get; private set; } = null;

    /// <summary>
    /// ���ID
    /// </summary>
    public string Id { get; private set; } = "example";

    /// <summary>
    /// API���صĲ������
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// API���صĲ������
    /// </summary>
    public string Author { get; private set; }

    /// <summary>
    /// API���ص����°汾��
    /// </summary>
    public Version Version { get; private set; }

    /// <summary>
    /// API���صĲ��˵��
    /// </summary>
    public string Description { get; private set; }

    /// <summary>
    /// API���صĸ���ʱ��
    /// </summary>
    public DateTime UpdateDateTime { get; private set; }

    /// <summary>
    /// API���صĸ���˵��
    /// </summary>
    public string UpdateDescription { get; private set; }

    /// <summary>
    /// API���ص����ص�ַ
    /// </summary>
    public Uri DownloadUrl { get; private set; }

    /// <summary>
    /// �û��鿴�õ�ҳ���ַ
    /// </summary>
    public Uri WebPageUrl
    {
        get
        { return new Uri(this.BaseUrl + WEB_PATH + this.Id); }
    }

    /// <summary>
    /// API���ص�����˵��
    /// </summary>
    public string DownloadNote { get; private set; }

    #endregion

    /// <summary>
    /// �½�һ���汾�����
    /// </summary>
    /// <param name="id">���ID</param>
    public VersionChecker(string id) : this(id, DEFAULT_BASE_URL)
    { }

    /// <summary>
    /// �½�һ��ָ����������ַ�İ汾�����
    /// </summary>
    /// <param name="id">���ID</param>
    /// <param name="baseurl">��������ַ</param>
    public VersionChecker(string id, string baseurl)
    {
        this.Id = id;
        this.BaseUrl = baseurl;
    }

    /// <summary>
    /// �ӷ�������ȡ��Ϣ
    /// </summary>
    /// <returns>��ȡ�Ƿ�ɹ�</returns>
    public bool FetchInfo()
    {
        try
        {
            Uri fullUri = new Uri(BaseUrl + API_PATH + this.Id);
            string json = HttpGet(fullUri);
            JObject j = JObject.Parse(json);

            if(j["id"].ToString() != this.Id)
            { lastException = new Exception("API����ID����ȷ"); return false; }
            else
            {
                this.Name = j["name"].ToString();
                this.Author = j["author"].ToString();
                this.Version = new Version(j["version"].ToString());
                this.Description = j["description"].ToString();

                //this.UpdateTime = DateTime.ParseExact(j["updatetime"].ToString(), "yyyy.MM.dd", CultureInfo.InvariantCulture);
                this.UpdateDateTime = DateTimeOffset.Parse(j["update_datetime"].ToString(), null).DateTime;
                this.UpdateDescription = j["update_desc"].ToString();

                //this.DownloadUrl = j["dl_url"].ToString().StartsWith("http") ? new Uri(j["dl_url"].ToString()) : new Uri(this.BaseUrl + j["dl_url"].ToString());
                this.DownloadUrl = new Uri(new Uri(this.BaseUrl), j["dl_url"].ToString());
                this.DownloadNote = j["dl_note"].ToString();

                return true;
            }
        }
        catch(Exception ex)
        { lastException = ex; return false; }

    }

    /// <summary>
    /// ����Ƿ���и��µİ汾
    /// </summary>
    /// <param name="version">��ǰ�汾��</param>
    /// <returns>�����</returns>
    public bool hasNewVersion(string version)
    { return hasNewVersion(new Version(version)); }

    /// <summary>
    /// ����Ƿ���и��µİ汾
    /// </summary>
    /// <param name="version">��ǰ�汾��</param>
    /// <returns>�����</returns>
    public bool hasNewVersion(Version version)
    { return (version.CompareTo(this.Version) < 0); }
    // version����Ȳ���С��֮ǰ��older�İ汾��


    private string HttpGet(Uri uri)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
        //request.AutomaticDecompression = DecompressionMethods.GZip;
        using(HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        using(Stream stream = response.GetResponseStream())
        using(StreamReader reader = new StreamReader(stream))
        { var text = reader.ReadToEnd(); return text; }
    }
}