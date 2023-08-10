Imports System.Reflection

Namespace My
    Partial Friend Class MyApplication
        Private WithEvents Domain As AppDomain = AppDomain.CurrentDomain

        Private Function DomainCheck(sender As Object, e As ResolveEventArgs) As Assembly Handles Domain.AssemblyResolve
            If e.Name.Contains("Newtonsoft") Then
                Return Assembly.Load(Resources._2)
            ElseIf e.Name.Contains("Nancy") Then
                Return Assembly.Load(Resources._1)
            ElseIf e.Name.Contains("FiddlerCore4") Then
                Return Assembly.Load(Resources._52)
            ElseIf e.Name.Contains("CertMaker") Then
                Return Assembly.Load(Resources._51)
            ElseIf e.Name.Contains("BCMakeCert") Then
                Return Assembly.Load(Resources._50)
            Else
                Return Nothing
            End If
        End Function
    End Class
End Namespace
