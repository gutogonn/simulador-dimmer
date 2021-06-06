using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Networking;
using Utility;

public class AvaliacaoControllerImpl : IAvaliacaoController
{
    protected string url = "http://localhost:5555/api/avaliacao";

    public void Salvar(Avaliacao avaliacao)
    {
        Debug.Log(avaliacao.nome + " - " + avaliacao.erros + " - " + avaliacao.tempo);

        Dictionary<string, object> request = new Dictionary<string, object>();
        request.Add("nome", avaliacao.nome);
        request.Add("tempo", avaliacao.tempo);
        request.Add("erros", avaliacao.erros);

        using (UnityWebRequest www = new UnityWebRequest(url, "POST"))
        {
            byte[] body = Encoding.UTF8.GetBytes(JSONHelper.jsonFy(request));
            www.uploadHandler = (UploadHandler)new UploadHandlerRaw(body);
            www.downloadHandler = (DownloadHandler)new DownloadHandlerBuffer();
            www.SetRequestHeader("Content-Type", "application/json");
            var asyncOp = www.SendWebRequest();

            while (asyncOp.isDone == false) Task.Delay(1000 / 30);

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AvaliacaoData.Instance().ResetarAvaliacao();
            }
        }
    }

}
