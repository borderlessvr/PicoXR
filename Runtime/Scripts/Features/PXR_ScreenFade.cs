﻿/************************************************************************************
 【PXR SDK】
 Copyright 2015-2020 Pico Technology Co., Ltd. All Rights Reserved.

************************************************************************************/

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.XR.PXR
{
    public class PXR_ScreenFade : MonoBehaviour
    {
        [Tooltip("Define the duration of screen fade.")]
        public float fadeTime = 5.0f;
        [Tooltip("Define the color of screen fade.")]
        public Color fadeColor = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        public int renderQueue = 5000;
        private MeshRenderer fadeMeshRenderer;
        private MeshFilter fadeMeshFilter;
        private Material fadeMaterial = null;
        private bool isFading = false;
        private float currentAlpha;
        private float nowFadeAlpha;

        void Awake()
        {
            CreateFadeMesh();
            SetCurrentAlpha(0);
        }

        void Start()
        {
            StartCoroutine(ScreenFade(1, 0));
        }

        void OnDestroy()
        {
            DestoryFadeMesh();
        }

        private void CreateFadeMesh()
        {
            fadeMaterial = new Material(Shader.Find("PXR_SDK/PXR_Fade"));
            fadeMeshFilter = gameObject.AddComponent<MeshFilter>();
            fadeMeshRenderer = gameObject.AddComponent<MeshRenderer>();

            var mesh = new Mesh();
            fadeMeshFilter.mesh = mesh;

            Vector3[] vertices = new Vector3[4];

            float width = 2f;
            float height = 2f;
            float depth = 1f;

            vertices[0] = new Vector3(-width, -height, depth);
            vertices[1] = new Vector3(width, -height, depth);
            vertices[2] = new Vector3(-width, height, depth);
            vertices[3] = new Vector3(width, height, depth);

            mesh.vertices = vertices;

            int[] tri = new int[6];

            tri[0] = 0;
            tri[1] = 2;
            tri[2] = 1;

            tri[3] = 2;
            tri[4] = 3;
            tri[5] = 1;

            mesh.triangles = tri;

            Vector3[] normals = new Vector3[4];

            normals[0] = -Vector3.forward;
            normals[1] = -Vector3.forward;
            normals[2] = -Vector3.forward;
            normals[3] = -Vector3.forward;

            mesh.normals = normals;

            Vector2[] uv = new Vector2[4];

            uv[0] = new Vector2(0, 0);
            uv[1] = new Vector2(1, 0);
            uv[2] = new Vector2(0, 1);
            uv[3] = new Vector2(1, 1);

            mesh.uv = uv;
        }

        private void DestoryFadeMesh()
        {
            if (fadeMeshRenderer != null)
                Destroy(fadeMeshRenderer);

            if (fadeMaterial != null)
                Destroy(fadeMaterial);

            if (fadeMeshFilter != null)
                Destroy(fadeMeshFilter);
        }

        public void SetCurrentAlpha(float alpha)
        {
            currentAlpha = alpha;
            SetMaterialAlpha();
        }

        public IEnumerator FadeIn()
        {
            yield return ScreenFade(0, 1);
        }

        public IEnumerator FadeOut()
        {
            yield return ScreenFade(1, 0);
        }

        IEnumerator ScreenFade(float startAlpha, float endAlpha, UnityAction onComplete = null)
        {
            float elapsedTime = 0.0f;
            while (elapsedTime < fadeTime)
            {
                elapsedTime += Time.deltaTime;
                nowFadeAlpha = Mathf.Lerp(startAlpha, endAlpha, Mathf.Clamp01(elapsedTime / fadeTime));
                SetMaterialAlpha();
                yield return new WaitForEndOfFrame();
            }

            onComplete?.Invoke();
        }

        private void SetMaterialAlpha()
        {
            Color color = fadeColor;
            color.a = Mathf.Max(currentAlpha, nowFadeAlpha);
            isFading = color.a > 0;
            if (fadeMaterial != null)
            {
                fadeMaterial.color = color;
                fadeMaterial.renderQueue = renderQueue;
                fadeMeshRenderer.material = fadeMaterial;
                fadeMeshRenderer.enabled = isFading;
                fadeMeshRenderer.sortingOrder = 4;
            }
        }
    }
}