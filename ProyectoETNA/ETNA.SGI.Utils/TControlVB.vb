Imports System.Data
Imports System.IO
Imports Microsoft.Office.Interop
Imports System.Windows.Forms

Public Class TControlVB
    Public Function Num2Text(ByVal value As Double) As String
        Select Case value
            Case 0 : Num2Text = "CERO"
            Case 1 : Num2Text = "UN"
            Case 2 : Num2Text = "DOS"
            Case 3 : Num2Text = "TRES"
            Case 4 : Num2Text = "CUATRO"
            Case 5 : Num2Text = "CINCO"
            Case 6 : Num2Text = "SEIS"
            Case 7 : Num2Text = "SIETE"
            Case 8 : Num2Text = "OCHO"
            Case 9 : Num2Text = "NUEVE"
            Case 10 : Num2Text = "DIEZ"
            Case 11 : Num2Text = "ONCE"
            Case 12 : Num2Text = "DOCE"
            Case 13 : Num2Text = "TRECE"
            Case 14 : Num2Text = "CATORCE"
            Case 15 : Num2Text = "QUINCE"
            Case Is < 20 : Num2Text = "DIECI" & Num2Text(value - 10)
            Case 20 : Num2Text = "VEINTE"
            Case Is < 30 : Num2Text = "VEINTI" & Num2Text(value - 20)
            Case 30 : Num2Text = "TREINTA"
            Case 40 : Num2Text = "CUARENTA"
            Case 50 : Num2Text = "CINCUENTA"
            Case 60 : Num2Text = "SESENTA"
            Case 70 : Num2Text = "SETENTA"
            Case 80 : Num2Text = "OCHENTA"
            Case 90 : Num2Text = "NOVENTA"
            Case Is < 100 : Num2Text = Num2Text(Int(value \ 10) * 10) & " Y " & Num2Text(value Mod 10)
            Case 100 : Num2Text = "CIEN"
            Case Is < 200 : Num2Text = "CIENTO " & Num2Text(value - 100)
            Case 200, 300, 400, 600, 800 : Num2Text = Num2Text(Int(value \ 100)) & "CIENTOS"
            Case 500 : Num2Text = "QUINIENTOS"
            Case 700 : Num2Text = "SETECIENTOS"
            Case 900 : Num2Text = "NOVECIENTOS"
            Case Is < 1000 : Num2Text = Num2Text(Int(value \ 100) * 100) & " " & Num2Text(value Mod 100)
            Case 1000 : Num2Text = "MIL"
            Case Is < 2000 : Num2Text = "MIL " & Num2Text(value Mod 1000)
            Case Is < 1000000 : Num2Text = Num2Text(Int(value \ 1000)) & " MIL"
                If value Mod 1000 Then Num2Text = Num2Text & " " & Num2Text(value Mod 1000)
            Case 1000000 : Num2Text = "UN MILLON"
            Case Is < 2000000 : Num2Text = "UN MILLON " & Num2Text(value Mod 1000000)
            Case Is < 1000000000000.0# : Num2Text = Num2Text(Int(value / 1000000)) & " MILLONES "
                If (value - Int(value / 1000000) * 1000000) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000) * 1000000)
            Case 1000000000000.0# : Num2Text = "UN BILLON"
            Case Is < 2000000000000.0# : Num2Text = "UN BILLON " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
            Case Else : Num2Text = Num2Text(Int(value / 1000000000000.0#)) & " BILLONES"
                If (value - Int(value / 1000000000000.0#) * 1000000000000.0#) Then Num2Text = Num2Text & " " & Num2Text(value - Int(value / 1000000000000.0#) * 1000000000000.0#)
        End Select
    End Function

    Function NumeroDec(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As System.Windows.Forms.TextBox) As Integer
        Dim dig As Integer = Len(Text.Text & e.KeyChar)
        Dim a, esDecimal, NumDecimales As Integer
        Dim esDec As Boolean
        Dim g As Boolean = e.KeyChar.IsDigit(e.KeyChar)

        ' se verifica si es un digito o un punto para el decimal 
        If e.KeyChar.IsDigit(e.KeyChar) Or e.KeyChar = "." Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
            Return a
        Else
            e.Handled = True
        End If
        ' se verifica que el primer digito ingresado no sea un punto al seleccionar 
        If Text.SelectedText <> "" Then
            If e.KeyChar = "." Then
                e.Handled = True
                Return a
            End If
        End If

        If dig = 1 And e.KeyChar = "." Then
            e.Handled = True
            Return a
        End If
        ' aqui se hace la verificacion cuando es seleccionado el valor del texto 
        'y no sea considerado como la adicion de un digito mas al valor ya contenido en el textbox
        If Text.SelectedText = "" Then
            ' aqui se hace el for para controlar que el numero sea de dos digitos - contadose a partir del punto decimal.
            For a = 0 To dig - 1
                Dim car As String = CStr(Text.Text & e.KeyChar)
                If car.Substring(a, 1) = "." Then
                    esDecimal = esDecimal + 1
                    esDec = True
                End If
                If esDec = True Then
                    NumDecimales = NumDecimales + 1
                End If
                ' aqui se controla los digitos a partir del punto numdecimales = 4 si es de dos decimales  
                If NumDecimales >= 5 Or esDecimal >= 3 Then
                    e.Handled = True
                End If
            Next
        End If
    End Function

    Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByVal Text As System.Windows.Forms.TextBox) As Integer

        Dim dig As Integer = Len(Text.Text & e.KeyChar)
        Dim a As Integer
        Dim g As Boolean = e.KeyChar.IsDigit(e.KeyChar)
        ' se verifica si es un digito o un punto para el decimal 
        If e.KeyChar.IsDigit(e.KeyChar) Then
            e.Handled = False
        ElseIf e.KeyChar.IsControl(e.KeyChar) Then
            e.Handled = False
            Return a
        Else
            e.Handled = True
        End If

    End Function


    '-----------------------------------------------
    'Convierte Números a Letras Hasta 999,999.99
    '-----------------------------------------------
    Function TextoNumero(ByVal numero As String) As String

        Dim u(0 To 100) As String
        Dim c(0 To 10) As String

        Dim LongitudTotal, UbicacionPunto As Integer
        Dim ParteEntera, ParteDecimal, CorreccionCien, CorreccionCienMil, CorreccionUno As String

        u(0) = ""
        u(1) = "Un"
        u(2) = "Dos"
        u(3) = "Tres"
        u(4) = "Cuatro"
        u(5) = "Cinco"
        u(6) = "Seis"
        u(7) = "Siete"
        u(8) = "Ocho"
        u(9) = "Nueve"
        u(10) = "Diez"
        u(11) = "Once"
        u(12) = "Doce"
        u(13) = "Trece"
        u(14) = "Catorce"
        u(15) = "Quince"
        u(16) = "Dieciseis"
        u(17) = "Diecisiete"
        u(18) = "Dieciocho"
        u(19) = "Diecinueve"
        u(20) = "Veinte"
        u(21) = "Veintiun"
        u(22) = "Veintidos"
        u(23) = "Veintitres"
        u(24) = "Veinticuatro"
        u(25) = "Veinticinco"
        u(26) = "Veintiseis"
        u(27) = "Veintisiete"
        u(28) = "Veintiocho"
        u(29) = "Veintinueve"
        u(30) = "Treinta"
        u(31) = "Treintaiun"
        u(32) = "Treintaidos"
        u(33) = "Treintaitres"
        u(34) = "Treintaicuatro"
        u(35) = "Treintaicinco"
        u(36) = "Treintaiseis"
        u(37) = "Treintaisiete"
        u(38) = "Treintaiocho"
        u(39) = "Treintainueve"
        u(40) = "Cuarenta"
        u(41) = "Cuarentaiun"
        u(42) = "Cuarentaidos"
        u(43) = "Cuarentaitres"
        u(44) = "Cuarentaicuatro"
        u(45) = "Cuarentaicinco"
        u(46) = "Cuarentaiseis"
        u(47) = "Cuarentaisiete"
        u(48) = "Cuarentaiocho"
        u(49) = "Cuarentainueve"
        u(50) = "Cincuenta"
        u(51) = "Cincuentaiuno"
        u(52) = "Cincuentaidos"
        u(53) = "Cincuentaitres"
        u(54) = "Cincuentaicuatro"
        u(55) = "Cincuentaicinco"
        u(56) = "Cincuentaiseis"
        u(57) = "Cincuentaisiete"
        u(58) = "Cincuentaiocho"
        u(59) = "Cincuentainueve"
        u(60) = "Sesenta"
        u(61) = "Sesentaiun"
        u(62) = "Sesentaidos"
        u(63) = "Sesentaitres"
        u(64) = "Sesentaicuatro"
        u(65) = "Sesentaicinco"
        u(66) = "Sesentaiseis"
        u(67) = "Sesentaisiete"
        u(68) = "Sesentaiocho"
        u(69) = "Sesentainueve"
        u(70) = "Setenta"
        u(71) = "Setentaiun"
        u(72) = "Setentaidos"
        u(73) = "Setentaitres"
        u(74) = "Setentaicuatro"
        u(75) = "Setentaicinco"
        u(76) = "Setentaiseis"
        u(77) = "Setentaisiete"
        u(78) = "Setentaiocho"
        u(79) = "Setentainueve"
        u(80) = "Ochenta"
        u(81) = "Ochentaiun"
        u(82) = "Ochentaidos"
        u(83) = "Ochentaitres"
        u(84) = "Ochentaicuatro"
        u(85) = "Ochentaicinco"
        u(86) = "Ochentaiseis"
        u(87) = "Ochentaisiete"
        u(88) = "Ochentaiocho"
        u(89) = "Ochentainueve"
        u(90) = "Noventa"
        u(91) = "Noventaiun"
        u(92) = "Noventaidos"
        u(93) = "Noventaitres"
        u(94) = "Noventaicuatro"
        u(95) = "Noventaicinco"
        u(96) = "Noventaiseis"
        u(97) = "Noventaisiete"
        u(98) = "Noventaiocho"
        u(99) = "Noventainueve"
        u(100) = "Cien"

        c(0) = ""
        c(1) = "Ciento"
        c(2) = "Doscientos"
        c(3) = "Trecientos"
        c(4) = "Cuatrocientos"
        c(5) = "Quinientos"
        c(6) = "Seiscientos"
        c(7) = "Setecientos"
        c(8) = "Ochocientos"
        c(9) = "Novecientos"
        c(10) = "Mil"

        numero = Format(Val(numero), "#######0.00")
        LongitudTotal = Len(Trim(numero))
        UbicacionPunto = InStr(numero, ".")
        ParteEntera = Mid(numero, 1, UbicacionPunto - 1)
        ParteDecimal = Mid(numero, UbicacionPunto + 1, 2)

        Select Case Len(ParteEntera)
            Case 1
                If ParteEntera = "1" Then
                    CorreccionUno = "Uno"
                Else
                    CorreccionUno = u(Val(ParteEntera))
                End If
                TextoNumero = CorreccionUno

            Case 2
                TextoNumero = u(Val(ParteEntera))

            Case 3
                If ParteEntera = "100" Then
                    CorreccionCien = "Cien"
                Else
                    CorreccionCien = c(Val(Mid(ParteEntera, 1, 1)))
                End If
                TextoNumero = CorreccionCien & " " & u(Val(Mid(ParteEntera, 2, 2)))

            Case 4
                If Mid(ParteEntera, 2, 3) = "100" Then
                    CorreccionCien = "Cien"
                Else
                    CorreccionCien = c(Val(Mid(ParteEntera, 2, 1)))
                End If
                TextoNumero = u(Val(Mid(ParteEntera, 1, 1))) & " mil " & CorreccionCien & " " & u(Val(Mid(ParteEntera, 3, 2)))

            Case 5
                If Mid(ParteEntera, 3, 3) = "100" Then
                    CorreccionCien = "Cien"
                Else
                    CorreccionCien = c(Val(Mid(ParteEntera, 3, 1)))
                End If
                TextoNumero = u(Val(Mid(ParteEntera, 1, 2))) & " mil " & CorreccionCien & " " & u(Val(Mid(ParteEntera, 4, 2)))

            Case 6
                If Mid(ParteEntera, 4, 3) = "100" Then
                    CorreccionCien = "Cien"
                Else
                    CorreccionCien = c(Val(Mid(ParteEntera, 4, 1)))
                End If
                If Mid(ParteEntera, 1, 3) = "100" Then
                    CorreccionCienMil = "Cien"
                Else
                    CorreccionCienMil = c(Val(Mid(ParteEntera, 1, 1)))
                End If
                TextoNumero = CorreccionCienMil & " " & u(Val(Mid(ParteEntera, 2, 2))) & "mil " & CorreccionCien & " " & u(Val(Mid(ParteEntera, 5, 2)))

        End Select

        TextoNumero = UCase("Son: " & TextoNumero & " y " & ParteDecimal & "/100 ")

    End Function

End Class
