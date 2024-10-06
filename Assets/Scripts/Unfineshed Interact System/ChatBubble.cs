using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChatBubble : MonoBehaviour // not being used
{
    public static void CreateChatBubble(Transform parent, Vector3 localPosition, string text)
    {
        //Transform chatBubbleTransform = Instantiate(GameAssets.i.pfChatBubble, parent);
        //chatBubbleTransform.localPosition = localPosition;

        //chatBubbleTransform.GetComponent<ChatBubble>().Setup(text);
    }

    private SpriteRenderer backgroundSpriteRenderer;
    private TextMeshPro textMeshPro;

    private void Awake()
    {
        backgroundSpriteRenderer = transform.Find("Background").GetComponent<SpriteRenderer>();
        textMeshPro = transform.Find("Text").GetComponent<TextMeshPro>();
    }
    private void Setup(string text)
    {
        textMeshPro.SetText(text);
        textMeshPro.ForceMeshUpdate();
        Vector2 textSize = textMeshPro.GetRenderedValues(false);
        Vector2 padding = new Vector2(2f, 2f);
        backgroundSpriteRenderer.size = padding + textSize;
        backgroundSpriteRenderer.transform.localPosition = new Vector3(backgroundSpriteRenderer.size.x / 2f, 0);
    }
}
