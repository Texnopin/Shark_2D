using System.Collections;
using UnityEngine;

public class GeneralControl : MonoBehaviour
{
    public GameObject[] parts;

    [Header("Part 1")]
    [SerializeField] private SpriteRenderer obj_1;
    [SerializeField] private SpriteRenderer obj_2;
    [SerializeField] private SpriteRenderer obj_3;
    [SerializeField] private SpriteRenderer obj_4;
    [SerializeField] private SpriteRenderer obj_5;

    [Header("Part 2")]
    [SerializeField] private SpriteRenderer obj_1_2;
    [SerializeField] private SpriteRenderer obj_2_2;
    [SerializeField] private SpriteRenderer obj_3_2;
    [SerializeField] private SpriteRenderer obj_4_2;
    [SerializeField] private SpriteRenderer obj_5_2;
    [SerializeField] private SpriteRenderer obj_6_2;
    [SerializeField] private SpriteRenderer obj_7_2;
    [SerializeField] private SpriteRenderer obj_8_2;

    private float fadeDuration = 1f; // Длительность плавного перехода в секундах

    public void Complite(GameObject part)
    {
        switch (part.name)
        {
            case "Part1":
                StartCoroutine(FadeTransition(
                    new SpriteRenderer[] { obj_1, obj_2, obj_3, obj_4, obj_5 },
                    new SpriteRenderer[] { obj_1_2, obj_2_2, obj_3_2, obj_4_2, obj_5_2, obj_6_2, obj_7_2, obj_8_2 },
                    0, 1,
                    parts[0], parts[1]
                ));
                break;

            case "Part2":
                StartCoroutine(FadeTransition(
                    new SpriteRenderer[] { obj_1_2, obj_2_2, obj_3_2, obj_4_2, obj_5_2, obj_6_2, obj_7_2, obj_8_2 },
                    new SpriteRenderer[] { /* сюда можно добавить Part3 спрайты, если есть */ },
                    0, 2,
                    parts[1], parts[2]
                ));
                break;

            case "Part3":
                StartCoroutine(FadeTransition(
                    new SpriteRenderer[] { /* Part3 спрайты */ },
                    new SpriteRenderer[] { /* Part4 спрайты */ },
                    0, 3,
                    parts[2], parts[3]
                ));
                break;
        }
    }

    private IEnumerator FadeTransition(SpriteRenderer[] fadeOutSprites, SpriteRenderer[] fadeInSprites, int fadeInStartAlpha, int fadeInEndIndex, GameObject deactivatePart, GameObject activatePart)
    {
        // Плавно скрываем fadeOutSprites
        yield return StartCoroutine(FadeSprites(fadeOutSprites, 1f, 0f));

        // Отключаем текущий part и включаем следующий
        deactivatePart.SetActive(false);
        activatePart.SetActive(true);

        // Если есть спрайты для появления — плавно показываем
        if (fadeInSprites != null && fadeInSprites.Length > 0)
        {
            // Устанавливаем начальную прозрачность 0 для fadeInSprites
            foreach (var sr in fadeInSprites)
            {
                if (sr != null)
                {
                    Color c = sr.color;
                    c.a = 0f;
                    sr.color = c;
                }
            }

            // Плавно показываем fadeInSprites
            yield return StartCoroutine(FadeSprites(fadeInSprites, 0f, 1f));
        }
    }

    private IEnumerator FadeSprites(SpriteRenderer[] sprites, float fromAlpha, float toAlpha)
    {
        float elapsed = 0f;

        // Устанавливаем начальную альфу
        foreach (var sr in sprites)
        {
            if (sr != null)
            {
                Color c = sr.color;
                c.a = fromAlpha;
                sr.color = c;
            }
        }

        while (elapsed < fadeDuration)
        {
            elapsed += Time.deltaTime;
            float alpha = Mathf.Lerp(fromAlpha, toAlpha, elapsed / fadeDuration);

            foreach (var sr in sprites)
            {
                if (sr != null)
                {
                    Color c = sr.color;
                    c.a = alpha;
                    sr.color = c;
                }
            }

            yield return null;
        }

        // Гарантируем точное значение alpha в конце
        foreach (var sr in sprites)
        {
            if (sr != null)
            {
                Color c = sr.color;
                c.a = toAlpha;
                sr.color = c;
            }
        }
    }
}




/*using UnityEngine;

public class GeneralControl : MonoBehaviour
{
    public GameObject[] parts;

    [Header("Part 1")]
    [SerializeField] private SpriteRenderer obj_1;
    [SerializeField] private SpriteRenderer obj_2;
    [SerializeField] private SpriteRenderer obj_3;
    [SerializeField] private SpriteRenderer obj_4;
    [SerializeField] private SpriteRenderer obj_5;

    [Header("Part 2")]
    [SerializeField] private SpriteRenderer obj_1_2;
    [SerializeField] private SpriteRenderer obj_2_2;
    [SerializeField] private SpriteRenderer obj_3_2;
    [SerializeField] private SpriteRenderer obj_4_2;
    [SerializeField] private SpriteRenderer obj_5_2;
    [SerializeField] private SpriteRenderer obj_6_2;
    [SerializeField] private SpriteRenderer obj_7_2;
    [SerializeField] private SpriteRenderer obj_8_2;

    public void Complite(GameObject part)
    {
        switch (part.name)
        {
            case "Part1":
                parts[0].SetActive(false);
                parts[1].SetActive(true);
                break;
            case "Part2":
                parts[1].SetActive(false);
                parts[2].SetActive(true);
                break;
            case "Part3":
                parts[2].SetActive(false);
                parts[3].SetActive(true);
                break;
        }
    }
}*/

