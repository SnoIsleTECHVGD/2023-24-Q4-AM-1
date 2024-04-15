using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FullScreenRenderPassFeature : ScriptableRendererFeature
{
    [SerializeField]
    private Material material;

    class CustomRenderPass : ScriptableRenderPass
    {
        [SerializeField]
        private Material material;
        RTHandle tempTexture, sourceTexture;
        private LayerMask noPixelLayerMask;
        private LayerMask pixelateLayerMask;

        public CustomRenderPass(Material material, LayerMask noPixelLayerMask, LayerMask pixelateLayerMask) : base()
        {
            this.material = material;
            this.noPixelLayerMask = noPixelLayerMask;
            this.pixelateLayerMask = pixelateLayerMask;
        }

        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            sourceTexture = renderingData.cameraData.renderer.cameraColorTargetHandle;

            tempTexture =
                RTHandles.Alloc(
                    new RenderTargetIdentifier("_TempTexture"),
                    name: "_TempTexture");
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
            CommandBuffer commandBuffer = CommandBufferPool.Get("Full Screen Render Feature");

            RenderTextureDescriptor targetDescriptor =
                renderingData.cameraData.cameraTargetDescriptor;

            targetDescriptor.depthBufferBits = 0;

            commandBuffer.GetTemporaryRT(
                Shader.PropertyToID(tempTexture.name), targetDescriptor, FilterMode.Bilinear);

            // Check if the current camera's culling mask intersects with the "No Pixel" layer mask
            if ((renderingData.cameraData.camera.cullingMask & noPixelLayerMask) == 0)
            {
                // If the camera's culling mask intersects with the "No Pixel" layer mask, just copy the source texture to the target
                Blit(commandBuffer, sourceTexture, sourceTexture);
            }
            else if ((renderingData.cameraData.camera.cullingMask & pixelateLayerMask) != 0)
            {
                // If the camera's culling mask intersects with the "Pixelate" layer mask, apply the material
                Blit(commandBuffer, sourceTexture, tempTexture, material);
                Blit(commandBuffer, tempTexture, sourceTexture);
            }
            else
            {
                // If the camera's culling mask doesn't intersect with either the "No Pixel" or "Pixelate" layer masks, just copy the source texture to the target
                Blit(commandBuffer, sourceTexture, sourceTexture);
            }

            context.ExecuteCommandBuffer(commandBuffer);
            CommandBufferPool.Release(commandBuffer);
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
            tempTexture.Release();
        }
    }

    CustomRenderPass m_ScriptablePass;

    public override void Create()
    {
        LayerMask noPixelLayerMask = ~(1 << LayerMask.NameToLayer("No Pixel"));
        LayerMask pixelateLayerMask = 1 << LayerMask.NameToLayer("Pixelate");
        m_ScriptablePass = new CustomRenderPass(this.material, noPixelLayerMask, pixelateLayerMask);

// Before render
        m_ScriptablePass.renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        renderer.EnqueuePass(m_ScriptablePass);
    }
}