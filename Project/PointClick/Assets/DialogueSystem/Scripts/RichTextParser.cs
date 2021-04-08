using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RichTextParser
{
    public RichTextParser(string tagText)
    {
        this.TagText = tagText;
    }

    public string TagText { get; private set; }

    public static int CurrentIndex { get; set; }

        public static RichTextParser ParseText(string texttoParse)
    {
        var startNode = texttoParse.IndexOf('<');
        var endNode = texttoParse.IndexOf('>');

        var tag = texttoParse.Substring(startNode, endNode - startNode + 1);

        return new RichTextParser(tag);
    }

    public static void GetRichTextValue(string text)
    {
        var dialogueManager = DialogueManager.instance;

        for (int i = CurrentIndex; i < text.Length; i++)
        {
            CurrentIndex = i;
            var remainingtext = text.Substring(CurrentIndex, text.Length - CurrentIndex);

            if (remainingtext.StartsWith('<'.ToString()))
            {
                var parsedText = ParseText(dialogueManager.BodyToPrint);

                if (parsedText.TagText.Contains('/'.ToString()))
                {
                    dialogueManager.EndTag = parsedText.TagText;
                    dialogueManager.BodyToPrint = dialogueManager.BodyToPrint.Replace(parsedText.TagText, string.Empty);
                    CurrentIndex += parsedText.TagText.Length - 1;
                    return;
                }
                else
                {
                    dialogueManager.StartTag = parsedText.TagText;
                    dialogueManager.BodyToPrint = dialogueManager.BodyToPrint.Replace(parsedText.TagText, string.Empty);
                    var length = remainingtext.IndexOf('/') - remainingtext.IndexOf('>') - 2;
                    dialogueManager.AmountToRich = length;
                    CurrentIndex += parsedText.TagText.Length - 1;
                }
            }
        }
    }

}
