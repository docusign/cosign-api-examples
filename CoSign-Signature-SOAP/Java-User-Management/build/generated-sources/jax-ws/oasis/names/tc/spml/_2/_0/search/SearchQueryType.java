
package oasis.names.tc.spml._2._0.search;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.ExtensibleType;
import oasis.names.tc.spml._2._0.PSOIdentifierType;


/**
 * <p>Java class for SearchQueryType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SearchQueryType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ExtensibleType">
 *       &lt;sequence>
 *         &lt;element name="basePsoID" type="{urn:oasis:names:tc:SPML:2:0}PSOIdentifierType" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="targetID" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="scope" type="{urn:oasis:names:tc:SPML:2:0:search}ScopeType" />
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SearchQueryType", propOrder = {
    "basePsoID"
})
public class SearchQueryType
    extends ExtensibleType
{

    protected PSOIdentifierType basePsoID;
    @XmlAttribute(name = "targetID")
    protected String targetID;
    @XmlAttribute(name = "scope")
    protected ScopeType scope;

    /**
     * Gets the value of the basePsoID property.
     * 
     * @return
     *     possible object is
     *     {@link PSOIdentifierType }
     *     
     */
    public PSOIdentifierType getBasePsoID() {
        return basePsoID;
    }

    /**
     * Sets the value of the basePsoID property.
     * 
     * @param value
     *     allowed object is
     *     {@link PSOIdentifierType }
     *     
     */
    public void setBasePsoID(PSOIdentifierType value) {
        this.basePsoID = value;
    }

    /**
     * Gets the value of the targetID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTargetID() {
        return targetID;
    }

    /**
     * Sets the value of the targetID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTargetID(String value) {
        this.targetID = value;
    }

    /**
     * Gets the value of the scope property.
     * 
     * @return
     *     possible object is
     *     {@link ScopeType }
     *     
     */
    public ScopeType getScope() {
        return scope;
    }

    /**
     * Sets the value of the scope property.
     * 
     * @param value
     *     allowed object is
     *     {@link ScopeType }
     *     
     */
    public void setScope(ScopeType value) {
        this.scope = value;
    }

}
