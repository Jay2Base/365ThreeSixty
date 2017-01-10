Public Class Form1

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim number1 As Integer

        number1 = 10
        Call incrementValue(number1)
        MsgBox(number1)


    End Sub
    Private Sub incrementValue(ByRef number1 As Integer)
        number1 = number1 + 1
    End Sub



    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim first As Integer
        Dim second As Integer

        first = Val(firstNumber.Text)
        second = Val(secondNumber.Text)

        Call addNumbers(first, second)
    End Sub

    Private Sub addNumbers(first As Integer, second As Integer)

        Dim answer As Integer


        answer = first + second

        MessageBox.Show("The answer is " & answer)

    End Sub
End Class
