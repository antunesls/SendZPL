
# sendZPL – TCP Socket Sender para Protheus (VB.NET / .NET 6)

Este é um utilitário de linha de comando desenvolvido em **VB.NET** com **.NET 6**, projetado para enviar comandos via **TCP Socket** diretamente da **máquina local**. Ideal para uso com o **Protheus** quando a comunicação com impressoras ou dispositivos TCP/IP precisa ser feita pela estação (cliente) e **não pelo AppServer**.

---

## ⚙️ Funcionalidade

Permite o envio de strings via protocolo TCP para um IP e porta específicos, comumente utilizado para:

- Impressoras Zebra (ZPL/EPL)
- Equipamentos industriais com interface de rede
- Testes e automações com sockets TCP

---

## 🚀 Como usar

### Sintaxe:

```bash
sendZPL.exe <IP> <PORTA> "<COMANDO>"
```

### Parâmetros:

- `IP` – Endereço IP de destino (ex: `192.168.0.100`)
- `PORTA` – Porta TCP do dispositivo (ex: `9100`)
- `COMANDO` – Texto/comando a ser enviado via socket (ex: `^XA^FO50,50^FDTeste^FS^XZ`)

### Exemplo:

```bash
sendZPL.exe 192.168.0.110 9100 "^XA^FO50,50^ADN,36,20^FDZebra Teste^FS^XZ"
```

---

## 🧩 Integração com o Protheus (ADVPL)

Você pode utilizar a função `WinExec()` no Protheus para executar o `sendZPL.exe` diretamente da máquina local (cliente):

```advpl
// Exemplo ADVPL para envio de etiqueta ZPL via socket

Local cIP1    := "192.168.0.110"
Local nPorta  := 9100
Local cEtiq   := "^XA^FO100,100^FDEnviado pelo Protheus^FS^XZ"
Local nErr    := 0

// Monta o comando usando MV para permitir caminho configurável
nErr := WinExec(GetMV("MV_XTECMH",, "C:\zpl\sendZPL.exe ") + ;
                cIP1 + " " + Str(nPorta) + ' "' + cEtiq + '"')

// Trata erro de execução
If nErr <> 0
    MsgStop("Falha ao iniciar a aplicação. Erro de OS = " + cValToChar(nErr))
EndIf
```

> 🛠️ **Dica:** Configure a variável MV `MV_XTECMH` com o caminho do executável (`C:\zpl\sendZPL.exe `) para facilitar a manutenção e atualização futura.

> ⚠️ **Atenção:** Esse comando será executado **na estação de trabalho do usuário**, e o dispositivo (ex: impressora) precisa estar acessível pela rede local.

---

## 📦 Requisitos

- **.NET 6 Runtime** instalado na máquina local
- Sistema operacional Windows (Windows 10 ou superior recomendado)
- Permissões para execução de programas externos via linha de comando

---

## 🔧 Compilação

O projeto pode ser aberto e compilado com o **Visual Studio 2022+** ou utilizando o CLI do .NET 6:

```bash
dotnet build -c Release
```

O executável gerado estará na pasta:

```bash
.\bin\Release\net6.0\
```

---

## 📄 Licença

Distribuído sob a licença **MIT**. Você pode utilizar, modificar e distribuir livremente.

---

## ❓ Suporte

Dúvidas, bugs ou sugestões? Fique à vontade para entrar em contato ou criar uma *issue* neste repositório.
