Imports System.Net.Sockets
Imports System.Text

Module EnviaZPL

    Sub Main(args As String())

        If args.Length < 3 Then
            Console.WriteLine("Uso: EnviaZPL.exe <IP> <PORTA> <ZPL>")
            Return
        End If

        Dim ip As String = args(0)
        Dim porta As Integer = Integer.Parse(args(1))
        Dim zpl As String = args(2)

        Try
            Console.WriteLine("Conectando a {0}:{1}...", ip, porta)
            Using client As New TcpClient(ip, porta)
                Dim stream As NetworkStream = client.GetStream()
                Dim buffer As Byte() = Encoding.ASCII.GetBytes(zpl)

                Console.WriteLine("Enviando comando ZPL...")
                stream.Write(buffer, 0, buffer.Length)
                stream.Flush()
                Console.WriteLine("Comando enviado com sucesso.")
            End Using

        Catch ex As Exception
            Console.WriteLine("Erro: " & ex.Message)
        End Try

    End Sub

End Module
