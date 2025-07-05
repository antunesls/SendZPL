# Protheus TCP Socket Sender (VB.NET)

Este projeto é uma aplicação de linha de comando desenvolvida em **VB.NET** com o objetivo de **enviar comandos TCP via socket diretamente da máquina local**, sem depender do AppServer do Protheus. Ele foi projetado para atender cenários específicos onde o Protheus precisa executar comandos TCP/IP (como envio de etiquetas ZPL para impressoras Zebra) diretamente da estação de trabalho ou servidor de aplicação.

---

## 💡 Funcionalidade

Permite o envio de comandos arbitrários via TCP para um IP e porta especificados, ideal para:

- Impressoras de etiquetas (Zebra ZPL, EPL, etc)
- Equipamentos industriais com interface TCP/IP
- Dispositivos que aceitam comandos diretos via socket

---

## ⚙️ Como usar

### Sintaxe:

```bash
SocketSender.exe <IP> <PORTA> "<COMANDO>"
