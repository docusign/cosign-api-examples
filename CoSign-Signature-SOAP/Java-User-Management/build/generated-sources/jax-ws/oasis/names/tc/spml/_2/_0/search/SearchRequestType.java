
package oasis.names.tc.spml._2._0.search;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.RequestType;
import oasis.names.tc.spml._2._0.ReturnDataType;


/**
 * <p>Java class for SearchRequestType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SearchRequestType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}RequestType">
 *       &lt;sequence>
 *         &lt;element name="query" type="{urn:oasis:names:tc:SPML:2:0:search}SearchQueryType" minOccurs="0"/>
 *         &lt;element name="includeDataForCapability" type="{http://www.w3.org/2001/XMLSchema}string" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="returnData" type="{urn:oasis:names:tc:SPML:2:0}ReturnDataType" default="everything" />
 *       &lt;attribute name="maxSelect" type="{http://www.w3.org/2001/XMLSchema}int" />
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SearchRequestType", propOrder = {
    "query",
    "includeDataForCapability"
})
public class SearchRequestType
    extends RequestType
{

    protected SearchQueryType query;
    protected List<String> includeDataForCapability;
    @XmlAttribute(name = "returnData")
    protected ReturnDataType returnData;
    @XmlAttribute(name = "maxSelect")
    protected Integer maxSelect;

    /**
     * Gets the value of the query property.
     * 
     * @return
     *     possible object is
     *     {@link SearchQueryType }
     *     
     */
    public SearchQueryType getQuery() {
        return query;
    }

    /**
     * Sets the value of the query property.
     * 
     * @param value
     *     allowed object is
     *     {@link SearchQueryType }
     *     
     */
    public void setQuery(SearchQueryType value) {
        this.query = value;
    }

    /**
     * Gets the value of the includeDataForCapability property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the includeDataForCapability property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getIncludeDataForCapability().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link String }
     * 
     * 
     */
    public List<String> getIncludeDataForCapability() {
        if (includeDataForCapability == null) {
            includeDataForCapability = new ArrayList<String>();
        }
        return this.includeDataForCapability;
    }

    /**
     * Gets the value of the returnData property.
     * 
     * @return
     *     possible object is
     *     {@link ReturnDataType }
     *     
     */
    public ReturnDataType getReturnData() {
        if (returnData == null) {
            return ReturnDataType.EVERYTHING;
        } else {
            return returnData;
        }
    }

    /**
     * Sets the value of the returnData property.
     * 
     * @param value
     *     allowed object is
     *     {@link ReturnDataType }
     *     
     */
    public void setReturnData(ReturnDataType value) {
        this.returnData = value;
    }

    /**
     * Gets the value of the maxSelect property.
     * 
     * @return
     *     possible object is
     *     {@link Integer }
     *     
     */
    public Integer getMaxSelect() {
        return maxSelect;
    }

    /**
     * Sets the value of the maxSelect property.
     * 
     * @param value
     *     allowed object is
     *     {@link Integer }
     *     
     */
    public void setMaxSelect(Integer value) {
        this.maxSelect = value;
    }

}
