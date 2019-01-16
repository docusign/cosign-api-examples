/*
 * DSA Rest v1.0 Simple Client
 * Signs a PDF with https://[DSA-machine-URL]:8081/sapiws/v1/digital_signature
 */
package com.docusign.dsarestclient;

import com.mashape.unirest.http.HttpResponse;
import com.mashape.unirest.http.Unirest;
import com.mashape.unirest.http.exceptions.UnirestException;
import java.io.File;
import java.io.FileInputStream;
import java.util.Base64;

public class DSARestClient 
{
    public static void main(String[] args) throws UnirestException 
    {
        //read file name, signer name, signer password from command line
        if (args.length < 3) 
        {
            System.out.println("Usage: java DSARestClient <pdf-file> <signer-name> <signer-password> [DSA-machine-URL]");
            return;
        }
        
        String FileName = args[0];          //PDF to Sign
        String SignerName = args[1];        //DSA user
        String SignerPassword = args[2];    //DSA user password

        String DSA  = "prime-dsa-devctr.docusign.net";  //DSA Developer Sandboxes machine
        if (args.length > 3)
            DSA = args[3];
        
        System.out.println("Trying to sign '" +FileName+ "' by '"+SignerName+ "' with password '"+SignerPassword+ "'");
        System.out.println("With '" + DSA + "'");
        if (!checkFile(FileName)) 
        {
            System.out.println("Cannot find '"+FileName+"' or it is read/write protected. Aborting.");
            return;
        }
        
        //set document properties
        byte[] fileBytes = getPDFBytes(FileName);
        byte[] B64EncodedFileBytes = Base64.getEncoder().encode(fileBytes);
        byte[] B64DSAAuthorization = Base64.getEncoder().encode((SignerName+":"+SignerPassword).getBytes());
        
        HttpResponse<String> response;
        response = Unirest.put("https://"+DSA+":8081/sapiws/v1/digital_signature")
                .header("authorization", "Basic " + new String(B64DSAAuthorization)) //Sm9obiBNaWxsZXI6MTIzNDU2Nzg=
                .header("content-type", "application/json")
                .body("{  " +
                        "\"CreateAndSignField\" : " +
                        "{  " + 
                            "\"file\": \""+new String(B64EncodedFileBytes)+"\", " + 
                            "\"FileType\": \"PDF\", " + 
                            "\"x\":\"271\", " + 
                            "\"y\":\"157\", " +
                            "\"width\":\"114\", " + 
                            "\"height\":\"59\", " +
                            "\"Reason\":\"Purchase approved\", " + 
                            "\"appearance\": [\"GRAPHICAL_IMAGE\", \"SIGNED_BY\", \"REASON\"]" + 
                        "}  " +
                      "}")
                .asString();
        System.out.println(response.getBody());
    }

    private static byte[] getPDFBytes(String FileName) 
    {
        byte[] pdf;
        // READ THE FILE INTO BUFFER
        try
        {
            File F = new File(FileName);

            if (!F.canRead())
            {
                return null;
            }

            if (!F.canWrite())
            {
                return null;
            }

            pdf = new byte[(int) F.length()];
            FileInputStream FH = new FileInputStream(F);
            FH.read(pdf, 0, (int) F.length());
            FH.close();
        }
        catch (Exception e)
        {
            return null;
        }
        return pdf;
    }    
    
    private static boolean checkFile(String fileName) 
    {
        try
        {
            File F = new File(fileName);

            if (!F.canRead())
            {
                return false;
            }

            if (!F.canWrite())
            {
                return false;
            }
        }
        catch (Exception e)
        {
            return false;
        }
        return true;
    }  
}
