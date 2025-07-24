using UnityEngine;

public class DottedLineScript : MonoBehaviour
{
    [SerializeField]
    Renderer targetRenderer;
    private MaterialPropertyBlock block;

    private void Update()
    {
        if (targetRenderer == null) return;

        if (block == null)
            block = new MaterialPropertyBlock();

        targetRenderer.GetPropertyBlock(block);
        block.SetFloat("_IsPlaying", Application.isPlaying ? 1f : 0f);
        targetRenderer.SetPropertyBlock(block);
    }
}
