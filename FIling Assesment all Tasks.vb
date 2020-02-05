
Module Module1
    Dim name As String
    Dim ID As String


    Sub Main()
        Dim selection As String
        selection = "0"

        Console.WriteLine("keep in mind this program saves all files in local disk E under the path E:/<filename>")
        Console.WriteLine("you wont need to add a .txt file extension when mentioning file names as the program does it for you")
        Console.WriteLine("")
        Console.WriteLine("WELCOME TO RECORD MANAGER")
        Console.WriteLine("")

        Do Until selection > "0" And selection < "6"

            Console.WriteLine("choose from the following: ")
            Console.WriteLine("1: create a new records file")
            Console.WriteLine("2: output a file's contents")
            Console.WriteLine("3: search for a record in a file")
            Console.WriteLine("4: add data of new members in an existing file")
            Console.WriteLine("5: add telephone numbers and adresses to records (this makes a new file)")

            selection = Console.ReadLine
            If selection > "6" Or selection < "0" Then
                Console.Clear()
                Console.WriteLine("enter a valid number")
            End If

        Loop
        If selection = "1" Then Call filemake()
        If selection = "2" Then Call outputrecord()
        If selection = "3" Then Call search()
        If selection = "4" Then Call newmembers()
        If selection = "5" Then Call newrec()



    End Sub

    Sub filemake()
        Dim addmore As Boolean
        Dim fname As String

        Console.Clear()

        addmore = True

        Console.WriteLine("what would you like to name your file?")
        fname = Console.ReadLine

        FileOpen(1, "E:/" & fname & ".txt", OpenMode.Output)

        Do Until addmore = False

            Console.WriteLine("enter a name")
            name = Console.ReadLine
            name = LCase(name)
            WriteLine(1, name)
            Console.WriteLine("enter an ID")
            ID = Console.ReadLine
            WriteLine(1, ID)
            Console.WriteLine("would you like to add more records?")
            If Console.ReadLine = "n" Then addmore = False

        Loop

        FileClose(1)
        Console.ReadKey()

    End Sub
    Sub outputrecord()
        Dim fname As String

        Console.Clear()

        Console.WriteLine("which files contents would like you like to output")
        fname = Console.ReadLine

        FileOpen(1, "E:/" & fname & ".txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, name)
            Input(1, ID)

            Console.WriteLine("Name: " & name)
            Console.WriteLine("ID: " & ID)
        End While
        FileClose(1)

        Console.ReadKey()

    End Sub
    Sub search()
        Console.Clear()
        Dim str1 As String
        Dim found As Boolean
        Dim fname As String

        Console.WriteLine("which file yould you like to search in?")
        fname = Console.ReadLine

        Console.WriteLine("what are you searching for?")
        str1 = Console.ReadLine
        str1 = LCase(str1)
        found = False



        FileOpen(1, "E:/" & fname & ".txt", OpenMode.Input)
        While Not EOF(1)
            Input(1, name)
            Input(1, ID)
            If name = str1 Then
                found = True
                Exit While
            End If
        End While

        If found = True Then
            Console.WriteLine("your query " & str1 & " has been found, the ID associated is " & ID)
        Else : Console.WriteLine("your query wasnt found")
        End If

        FileClose(1)
        Console.ReadKey()

    End Sub
    Sub newmembers()
        Dim fname As String
        Dim newname As String
        Dim newID As String
        Dim addmore As Boolean
        Dim ans As String

        Console.Clear()
        addmore = True
        newname = ""
        newID = ""
        ans = ""

        Console.WriteLine("enter the file name in which you would like to add member data")
        fname = Console.ReadLine

        FileOpen(1, "E:/" & fname & ".txt", OpenMode.Append)
        Do Until addmore = False

            Console.WriteLine("enter the name you would like to enter") : newname = Console.ReadLine
            WriteLine(1, newname)
            Console.WriteLine("enter the associated ID") : newID = Console.ReadLine
            WriteLine(1, newID)
            Console.WriteLine("would you like to add more records? y/n") : ans = Console.ReadLine
            If ans = "N" Or ans = "n" Then
                addmore = False
            End If
        Loop
        FileClose(1)


    End Sub
    Sub newrec()
        Dim fname As String
        Dim newrecadd As Boolean
        Dim ans As String
        Dim telephone As String
        Dim membershipdate As String

        Console.Clear()
        telephone = ""
        membershipdate = ""
        ans = ""
        fname = ""
        newrecadd = True
        Console.WriteLine("which file would you like to add new records to?") : fname = Console.ReadLine


        FileOpen(1, "E:/" & fname & ".txt", OpenMode.Input)
        FileOpen(2, "E:/" & fname & "Extended.txt", OpenMode.Output)
        While Not EOF(1)
            name = ""
            ID = ""
            telephone = ""
            membershipdate = ""

            Input(1, name)
            Input(1, ID)
            Console.WriteLine("would you like to add telephone num and membership date to " & name & "? y/n")
            ans = Console.ReadLine
            If ans = "Y" Or ans = "y" Then
                Console.WriteLine("enter the telephone num of " & name) : telephone = Console.ReadLine
                Console.WriteLine("enter the membership start date of " & name) : membershipdate = Console.ReadLine
                WriteLine(2, name)
                WriteLine(2, ID)
                WriteLine(2, telephone)
                WriteLine(2, membershipdate)
            End If


        End While
        FileClose(1)
        FileClose(2)

    End Sub
End Module