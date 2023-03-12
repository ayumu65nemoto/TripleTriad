using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class OnlineCardManager : MonoBehaviourPunCallbacks
{
    private const string TAG_KEY = "TAG";

    public void SetTag(GameObject obj, string tag)
    {
        // Custom Properties�Ƀ^�O��ݒ肷��
        if (PhotonNetwork.IsMasterClient)
        {
            ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
            customProperties[TAG_KEY] = tag;
            obj.GetPhotonView().Owner.SetCustomProperties(customProperties);
        }
    }

    public override void OnPlayerPropertiesUpdate(Player targetPlayer, ExitGames.Client.Photon.Hashtable changedProps)
    {
        // Custom Properties���ύX���ꂽ���ɌĂяo�����
        if (targetPlayer == null || !targetPlayer.IsLocal) return;
        if (changedProps.ContainsKey(TAG_KEY))
        {
            string tag = (string)changedProps[TAG_KEY];
            gameObject.tag = tag;
        }
    }
}
