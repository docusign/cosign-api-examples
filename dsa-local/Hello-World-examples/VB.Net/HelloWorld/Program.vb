Imports SAPILib

Module Program
    Sub Main()
        Const SAPI_OK As Integer = 0

        Dim rc As Integer
        Dim SAPI As New SAPICryptClass
        Dim sesHandle As SESHandle = Nothing

        'Custom Values
        Dim filePath As String = "c:\\temp\\demo.pdf"   'PDF file to sign
        Dim username As String = "{signer_username}"    'CoSign account username
        Dim password As String = "{signer_password}"    'CoSign account password
        Dim domain As String = Nothing                  'CoSign account domain
        Dim sigPageNum As Integer = 1                   'Create signature on the first page
        Dim sigX As Integer = 145                       'Signature field X location
        Dim sigY As Integer = 125                       'Signature field Y location
        Dim sigWidth As Integer = 160                   'Signature field width
        Dim sigHeight As Integer = 45                   'Signature field height
        Dim timeFormat As String = "hh:mm:ss"           'Time appearance format mask
        Dim dateFormat As String = "dd/MM/yyyy"         'Date appearance format mask
        Dim appearanceMask As Integer = SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_GRAPHICAL_IMAGE Or _
                                        SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_SIGNED_BY Or _
                                        SAPI_ENUM_DRAWING_ELEMENT.SAPI_ENUM_DRAWING_ELEMENT_TIME                    'Elements to display on the signature field

        Try
            'Initialize SAPI library
            rc = SAPI.Init
            If rc <> SAPI_OK Then Throw New Exception(String.Format("Failed to initialize SAPI ({0})", rc.ToString("X")))

            'Acquire SAPI session handle
            rc = SAPI.HandleAcquire(sesHandle)
            If rc <> SAPI_OK Then Throw New Exception(String.Format("Failed in SAPIHandleAcquire() ({0})", rc.ToString("X")))

            'Personalize SAPI Session
            SAPI.Logon(sesHandle, username, domain, password)
            If rc <> SAPI_OK Then Throw New Exception(String.Format("Failed to authenticate user ({0})", rc.ToString("X")))

            'Instantiate SigFieldSettings object
            Dim SFS As New SigFieldSettingsClass
            Dim TF As New TimeFormatClass

            'Define signature field settings
            SFS.Page = sigPageNum
            SFS.X = sigX
            SFS.Y = sigY
            SFS.Width = sigWidth
            SFS.Height = sigHeight
            SFS.AppearanceMask = appearanceMask
            SFS.SignatureType = SAPI_ENUM_SIGNATURE_TYPE.SAPI_ENUM_SIGNATURE_DIGITAL
            SFS.DependencyMode = SAPI_ENUM_DEPENDENCY_MODE.SAPI_ENUM_DEPENDENCY_MODE_INDEPENDENT
            TF.DateFormat = dateFormat
            TF.TimeFormat = timeFormat
            TF.ExtTimeFormat = SAPI_ENUM_EXTENDED_TIME_FORMAT.SAPI_ENUM_EXTENDED_TIME_FORMAT_GMT    'Display GMT offset
            SFS.TimeFormat = TF

            Dim fileType As SAPI_ENUM_FILE_TYPE = SAPI_ENUM_FILE_TYPE.SAPI_ENUM_FILE_ADOBE  'Type of the file to sign - PDF
            Dim flags As Integer = 0

            'Create and sign a new signature field in the document
            rc = SAPI.SignatureFieldCreateSign(sesHandle, fileType, filePath, SFS, flags, Nothing)
            If rc <> SAPI_OK Then Throw New Exception(String.Format("Failed in SAPISignatureFieldCreateSign() ({0})", rc.ToString("X")))

            Console.WriteLine("The document has been successfully signed!")

        Catch ex As Exception
            Console.WriteLine(ex.Message)
        Finally
            If sesHandle IsNot Nothing Then
                SAPI.Logoff(sesHandle)         'Release user context
                SAPI.HandleRelease(sesHandle)  'Release session handle
            End If
        End Try
    End Sub
End Module
