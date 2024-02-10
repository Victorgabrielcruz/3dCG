﻿using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace Examples
{
    /// <summary>
    /// Limpar e dispor um Frame Buffer, utilizando a funcionalidade disponível na biblioteca OpenTK.
    /// </summary>
    internal class HelloSwapBuffers : GameWindow
    {
        Color4 bgColor = new Color4(0.0f, 0.0f, 0.0f, 1.0f);

        int taxaDeAtualizacao = 30;

        public HelloSwapBuffers(
            GameWindowSettings gameWindowSettings,
            NativeWindowSettings nativeWindowSettings) :
            base(gameWindowSettings, nativeWindowSettings) { }

        // O método 'OnLoad' é chamado uma vez, logo após a criação da janela.
        // Sua função é permitir que o usuário configure a janela, os objetos e
        // carregue os dados necessários antes de iniciar o loop de renderização.
        protected override void OnLoad()
        {
            base.OnLoad();

            // Configura a cor de fundo do Frame Buffer.
            GL.ClearColor(bgColor);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);

            bgColor.R += 0.0001f * taxaDeAtualizacao;
            bgColor.G += 0.000013f * taxaDeAtualizacao;
            bgColor.B += 0.00033f * taxaDeAtualizacao;
            if (bgColor.R > 1.0f) { bgColor.R = 0.0f; }
            if (bgColor.G > 1.0f) { bgColor.G = 0.0f; }
            if (bgColor.B > 1.0f) { bgColor.B = 0.0f; }

            GL.ClearColor(bgColor);
        }

        // O método 'OnRenderFrame' é chamado uma vez a cada frame. Sua função é
        // desenhar na tela, utilizando os dados disponíveis.
        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);

            // Limpa o Frame Buffer, utilizando a cor de fundo.
            GL.Clear(ClearBufferMask.ColorBufferBit);

            // AQUI VOCÊ DEVERÁ DESENHAR OS OBJETOS 

            // Disponibiliza o Frame Buffer na tela, alternando entre dois buffers que são pintados em sequência (Double buffering).
            SwapBuffers();
        }
    }
}
