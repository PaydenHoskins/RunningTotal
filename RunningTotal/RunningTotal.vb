'Payden Hoskins
'RCET 2265
'Spring 2025

Option Strict On
Option Compare Text
Option Explicit On


'TODO
'[ ] keep track of transactions in a  Function called runing total()
'[ ] get the current total as needed
'[ ] provide a  way to clear/zero the total
'[ ] super bonus: create a method to include sales tax to the transaction amount
Module RunningTotal

    Sub Main()
        Dim UserInput As String
        Dim AmountOwed As Decimal
        Dim AmountPaid As Decimal
        Dim MoveOn As Boolean
        MoveOn = False
        Do Until UserInput = "Q"
            Console.WriteLine("Input amount owed.")
            UserInput = Console.ReadLine()
            Do
                Try
                    AmountOwed = CDec(UserInput)
                    MoveOn = True
                Catch
                    Console.WriteLine("not a number")
                End Try
            Loop Until MoveOn = True
            MoveOn = False
            Console.WriteLine()
            Console.WriteLine("Input amount paid.")
            UserInput = Console.ReadLine()
            Do
                Do
                    Try
                        AmountPaid = CDec(UserInput)
                        MoveOn = True
                    Catch
                        Console.WriteLine("not a number")
                    End Try
                Loop Until MoveOn = True
                Console.WriteLine()
                Console.WriteLine("Change Owed.")
                RunningTotal(AmountOwed, "0")
                Console.WriteLine(FinalTotal(AmountOwed, AmountPaid))
                Console.WriteLine()
                Console.WriteLine("Would you like to see complete total of today?")
                UserInput = Console.ReadLine
                If UserInput = "Yes" Then
                    Console.WriteLine(RunningTotal(0, "1"))
                ElseIf UserInput = "Zero" Then
                    Console.WriteLine(RunningTotal(0, "2"))

                End If
            Loop Until UserInput = "Q" Or MoveOn = True
        Loop
    End Sub

    Function FinalTotal(ByRef Total As Decimal, ByRef Paid As Decimal) As Decimal
        Static change As Decimal
        change = CDec(Total - Paid)
        Return change
    End Function

    Function RunningTotal(ByRef OwedTotal As Decimal, ByRef Operation As String) As Decimal
        Static AddedTotal As Decimal
        Select Case Operation
            Case "0"
                AddedTotal += OwedTotal
            Case "1"
                AddedTotal += OwedTotal
            Case "2"
                AddedTotal -= AddedTotal
        End Select
        Return AddedTotal
    End Function
End Module
