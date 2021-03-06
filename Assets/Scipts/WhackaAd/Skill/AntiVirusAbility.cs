using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace WhackaAd
{
    public class AntiVirusAbility : MonoBehaviour
    {
        public WhackaAdSpawner Spawnner;
        public GameObject AntivirusUI;
        public float AntiVirusCooldownTime;

        int removed;

        public void AntiVirusMenu()
        {
            AntivirusUI.SetActive(true);
        }

        public void AntiVirus(int index)
        {
            Time.timeScale = 0.2f;
            if (Spawnner.AdwareTemp.Count == 1)
            {
                Spawnner.AdwareTemp.Add(Spawnner.Adwares[removed]);
                Spawnner.AdwareTemp.RemoveAt(0);
            }
            else if (Spawnner.AdwareTemp.Count > 1)
            {
                Spawnner.AdwareTemp.RemoveAt(index);
            }

            removed = index;
            AntivirusUI.SetActive(false);
            Time.timeScale = 1f;
            StartCoroutine(AntiVirusCooldown());
        }

        IEnumerator AntiVirusCooldown()
        {
            GameObject.Find("AntiVirusBtn").GetComponent<Button>().enabled = false;
            yield return new WaitForSeconds(AntiVirusCooldownTime);
            GameObject.Find("AntiVirusBtn").GetComponent<Button>().enabled = true;
        }
    }
}
