package cosignsapiumbasicsample;

import com.arx.sapiws.spml._1.CoSignLogonData;
import com.arx.sapiws.spml._1.SPML;
import com.arx.sapiws.spml._1.SPMLSoap;
import com.arx.sapiws.spml._1.UserRecord;
import java.net.MalformedURLException;
import java.net.URL;
import java.util.List;
import oasis.names.tc.spml._2._0.*;
import oasis.names.tc.spml._2._0.search.SearchRequestType;
import oasis.names.tc.spml._2._0.search.SearchResponseType;

/**
 *
 * @author Aviv Simionovici, Presale Engineer, ARX
 */
public class CoSignSapiUMBasicSample {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws MalformedURLException {
        //read howManyUsersToFetch, admin name, admin password from command line
        if (args.length < 3) {
            System.out.println("Usage: java CoSignSapiUMBasicSample <number-of-users> <admin-name> <admin-password>");
            return;
        }
        String howManyUsersToFetch = args[0];   //number of users to get from cosign server
        String AdminName = args[1];             //cosign admin user
        String AdminPassword = args[2];         //cosign admin user password
        int nUsersToFetch = Integer.parseInt(howManyUsersToFetch);
               
        //prepare CoSignLogonData
        CoSignLogonData coSignLogonData = new CoSignLogonData();
        coSignLogonData.setUser(AdminName);
        coSignLogonData.setPassword(AdminPassword);
        
        //build a search request
        SearchRequestType searchRequest = new SearchRequestType();
        searchRequest.setCoSignLogonData(coSignLogonData);
        searchRequest.setMaxSelect(nUsersToFetch);
        searchRequest.setReturnData(ReturnDataType.DATA);
        searchRequest.setExecutionMode(ExecutionModeType.SYNCHRONOUS);

        //build the spml client
        SPML spmlClient = new SPML(new URL("https://prime.cosigntrial.com:8080/SAPIWS/spml.asmx"));
        SPMLSoap SPMLSoapClient = spmlClient.getSPMLSoap();
        
        //perform the search
        SearchResponseType searchResponse = SPMLSoapClient.search(searchRequest);
        ErrorCode errCode = searchResponse.getError();
        if (errCode == null)
        {
            //print result
            List<PSOType> psoList = searchResponse.getPso();
            for (int i = 0; i < psoList.size(); i++) {
                PSOType pso = psoList.get(i);
                PSOIdentifierType psoID = pso.getPsoID();
                String iD = psoID.getID();
                UserRecord userRecord = pso.getUserRecord();
                String userCN = userRecord.getUserCN();
                String emailAddress = userRecord.getEmailAddress();
                long rightsMask = userRecord.getRightsMask();

                System.out.println((i+1) + ": " + iD + ", " + userCN + ", " + emailAddress + ", " + rightsMask);
            }
        }
        else {
                System.out.println( "Error "+ errCode.toString()+ " encountered when tried to fetch " + howManyUsersToFetch + " users from " + spmlClient.getWSDLDocumentLocation().toString());
        }
    }
}
