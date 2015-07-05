
package com.arx.sapiws.spml._1;

import java.net.URL;
import javax.xml.namespace.QName;
import javax.xml.ws.Service;
import javax.xml.ws.WebEndpoint;
import javax.xml.ws.WebServiceClient;
import javax.xml.ws.WebServiceException;
import javax.xml.ws.WebServiceFeature;


/**
 * This class was generated by the JAX-WS RI.
 * JAX-WS RI 2.2-hudson-752-
 * Generated source version: 2.2
 * 
 */
@WebServiceClient(name = "SPML", targetNamespace = "http://arx.com/SAPIWS/SPML/1.0/", wsdlLocation = "https://prime.cosigntrial.com:8080/SAPIWS/spml.asmx?WSDL")
public class SPML
    extends Service
{

    private final static URL SPML_WSDL_LOCATION;
    private final static WebServiceException SPML_EXCEPTION;
    private final static QName SPML_QNAME = new QName("http://arx.com/SAPIWS/SPML/1.0/", "SPML");

    static {
        SPML_WSDL_LOCATION = com.arx.sapiws.spml._1.SPML.class.getResource("https://prime.cosigntrial.com:8080/SAPIWS/spml.asmx?WSDL");
        WebServiceException e = null;
        if (SPML_WSDL_LOCATION == null) {
            e = new WebServiceException("Cannot find 'https://prime.cosigntrial.com:8080/SAPIWS/spml.asmx?WSDL' wsdl. Place the resource correctly in the classpath.");
        }
        SPML_EXCEPTION = e;
    }

    public SPML() {
        super(__getWsdlLocation(), SPML_QNAME);
    }

    public SPML(WebServiceFeature... features) {
        super(__getWsdlLocation(), SPML_QNAME, features);
    }

    public SPML(URL wsdlLocation) {
        super(wsdlLocation, SPML_QNAME);
    }

    public SPML(URL wsdlLocation, WebServiceFeature... features) {
        super(wsdlLocation, SPML_QNAME, features);
    }

    public SPML(URL wsdlLocation, QName serviceName) {
        super(wsdlLocation, serviceName);
    }

    public SPML(URL wsdlLocation, QName serviceName, WebServiceFeature... features) {
        super(wsdlLocation, serviceName, features);
    }

    /**
     * 
     * @return
     *     returns SPMLSoap
     */
    @WebEndpoint(name = "SPMLSoap")
    public SPMLSoap getSPMLSoap() {
        return super.getPort(new QName("http://arx.com/SAPIWS/SPML/1.0/", "SPMLSoap"), SPMLSoap.class);
    }

    /**
     * 
     * @param features
     *     A list of {@link javax.xml.ws.WebServiceFeature} to configure on the proxy.  Supported features not in the <code>features</code> parameter will have their default values.
     * @return
     *     returns SPMLSoap
     */
    @WebEndpoint(name = "SPMLSoap")
    public SPMLSoap getSPMLSoap(WebServiceFeature... features) {
        return super.getPort(new QName("http://arx.com/SAPIWS/SPML/1.0/", "SPMLSoap"), SPMLSoap.class, features);
    }

    /**
     * 
     * @return
     *     returns SPMLSoap
     */
    @WebEndpoint(name = "SPMLSoap12")
    public SPMLSoap getSPMLSoap12() {
        return super.getPort(new QName("http://arx.com/SAPIWS/SPML/1.0/", "SPMLSoap12"), SPMLSoap.class);
    }

    /**
     * 
     * @param features
     *     A list of {@link javax.xml.ws.WebServiceFeature} to configure on the proxy.  Supported features not in the <code>features</code> parameter will have their default values.
     * @return
     *     returns SPMLSoap
     */
    @WebEndpoint(name = "SPMLSoap12")
    public SPMLSoap getSPMLSoap12(WebServiceFeature... features) {
        return super.getPort(new QName("http://arx.com/SAPIWS/SPML/1.0/", "SPMLSoap12"), SPMLSoap.class, features);
    }

    private static URL __getWsdlLocation() {
        if (SPML_EXCEPTION!= null) {
            throw SPML_EXCEPTION;
        }
        return SPML_WSDL_LOCATION;
    }

}
