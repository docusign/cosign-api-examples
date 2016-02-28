
package oasis.names.tc.spml._2._0.search;

import javax.xml.bind.JAXBElement;
import javax.xml.bind.annotation.XmlElementDecl;
import javax.xml.bind.annotation.XmlRegistry;
import javax.xml.namespace.QName;


/**
 * This object contains factory methods for each 
 * Java content interface and Java element interface 
 * generated in the oasis.names.tc.spml._2._0.search package. 
 * <p>An ObjectFactory allows you to programatically 
 * construct new instances of the Java representation 
 * for XML content. The Java representation of XML 
 * content can consist of schema derived interfaces 
 * and classes representing the binding of schema 
 * type definitions, element declarations and model 
 * groups.  Factory methods for each of these are 
 * provided in this class.
 * 
 */
@XmlRegistry
public class ObjectFactory {

    private final static QName _IterateRequest_QNAME = new QName("urn:oasis:names:tc:SPML:2:0:search", "iterateRequest");
    private final static QName _SearchResponse_QNAME = new QName("urn:oasis:names:tc:SPML:2:0:search", "searchResponse");
    private final static QName _SearchRequest_QNAME = new QName("urn:oasis:names:tc:SPML:2:0:search", "searchRequest");
    private final static QName _CloseIteratorRequest_QNAME = new QName("urn:oasis:names:tc:SPML:2:0:search", "closeIteratorRequest");

    /**
     * Create a new ObjectFactory that can be used to create new instances of schema derived classes for package: oasis.names.tc.spml._2._0.search
     * 
     */
    public ObjectFactory() {
    }

    /**
     * Create an instance of {@link CloseIteratorRequestType }
     * 
     */
    public CloseIteratorRequestType createCloseIteratorRequestType() {
        return new CloseIteratorRequestType();
    }

    /**
     * Create an instance of {@link ResultsIteratorType }
     * 
     */
    public ResultsIteratorType createResultsIteratorType() {
        return new ResultsIteratorType();
    }

    /**
     * Create an instance of {@link SearchQueryType }
     * 
     */
    public SearchQueryType createSearchQueryType() {
        return new SearchQueryType();
    }

    /**
     * Create an instance of {@link SearchRequestType }
     * 
     */
    public SearchRequestType createSearchRequestType() {
        return new SearchRequestType();
    }

    /**
     * Create an instance of {@link IterateRequestType }
     * 
     */
    public IterateRequestType createIterateRequestType() {
        return new IterateRequestType();
    }

    /**
     * Create an instance of {@link SearchResponseType }
     * 
     */
    public SearchResponseType createSearchResponseType() {
        return new SearchResponseType();
    }

    /**
     * Create an instance of {@link LogicalOperatorType }
     * 
     */
    public LogicalOperatorType createLogicalOperatorType() {
        return new LogicalOperatorType();
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link IterateRequestType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "urn:oasis:names:tc:SPML:2:0:search", name = "iterateRequest")
    public JAXBElement<IterateRequestType> createIterateRequest(IterateRequestType value) {
        return new JAXBElement<IterateRequestType>(_IterateRequest_QNAME, IterateRequestType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link SearchResponseType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "urn:oasis:names:tc:SPML:2:0:search", name = "searchResponse")
    public JAXBElement<SearchResponseType> createSearchResponse(SearchResponseType value) {
        return new JAXBElement<SearchResponseType>(_SearchResponse_QNAME, SearchResponseType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link SearchRequestType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "urn:oasis:names:tc:SPML:2:0:search", name = "searchRequest")
    public JAXBElement<SearchRequestType> createSearchRequest(SearchRequestType value) {
        return new JAXBElement<SearchRequestType>(_SearchRequest_QNAME, SearchRequestType.class, null, value);
    }

    /**
     * Create an instance of {@link JAXBElement }{@code <}{@link CloseIteratorRequestType }{@code >}}
     * 
     */
    @XmlElementDecl(namespace = "urn:oasis:names:tc:SPML:2:0:search", name = "closeIteratorRequest")
    public JAXBElement<CloseIteratorRequestType> createCloseIteratorRequest(CloseIteratorRequestType value) {
        return new JAXBElement<CloseIteratorRequestType>(_CloseIteratorRequest_QNAME, CloseIteratorRequestType.class, null, value);
    }

}
