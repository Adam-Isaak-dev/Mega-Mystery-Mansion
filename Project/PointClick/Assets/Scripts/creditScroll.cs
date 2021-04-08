using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class creditScroll : MonoBehaviour
{
    public GameObject credits;
    public AudioSource source;
    public GameObject black;

    private void Start()
    {
        Cursor.visible = false;
        source.volume = PlayerPrefs.GetFloat("musicVol");
        if (source.volume == 0f)
            source.volume = 0.8f;
        black.SetActive(true);
        source.Stop();
        StartCoroutine(scroll());
    }

    public void Update()
    {
        bool esc = false;
        if ((Input.GetKeyDown("escape"))&&!esc)
        {
            esc = true;
            StartCoroutine(skip());
        }
    }

    IEnumerator scroll()
    {
        float i;
        yield return new WaitForSeconds(0.8f);
        for (i = 0; i<100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            black.GetComponent<Image>().color = new Color(0,0,0,1f-i/100f);
        }
        source.Play();
        black.SetActive(false);
        for (i = 0; credits.transform.localPosition.y <4270f; i++)
        {
            yield return new WaitForSeconds(0.01f);
            credits.transform.localPosition = new Vector2(0f, -775f+i);
        }

        yield return new WaitForSeconds(1f);
        black.SetActive(true);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            black.GetComponent<Image>().color = new Color(0, 0, 0, i / 100f);
        }
        yield return new WaitForSeconds(1f);
        source.Stop();
        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }

    IEnumerator skip()
    {
        float i;
        black.SetActive(true);
        for (i = 0; i < 100; i++)
        {
            yield return new WaitForSeconds(0.01f);
            black.GetComponent<Image>().color = new Color(0, 0, 0, i / 100f);
        }
        yield return new WaitForSeconds(0.2f);
        source.Stop();
        yield return new WaitForSeconds(0.1f);
        Cursor.visible = true;
        SceneManager.LoadScene(0);
    }
}
