
package oasis.names.tc.spml._2._0;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for SchemaEntityRefType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="SchemaEntityRefType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ExtensibleType">
 *       &lt;attribute name="targetID" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="entityName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="isContainer" type="{http://www.w3.org/2001/XMLSchema}boolean" />
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "SchemaEntityRefType")
public class SchemaEntityRefType
    extends ExtensibleType
{

    @XmlAttribute(name = "targetID")
    protected String targetID;
    @XmlAttribute(name = "entityName")
    protected String entityName;
    @XmlAttribute(name = "isContainer")
    protected Boolean isContainer;

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
     * Gets the value of the entityName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getEntityName() {
        return entityName;
    }

    /**
     * Sets the value of the entityName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEntityName(String value) {
        this.entityName = value;
    }

    /**
     * Gets the value of the isContainer property.
     * 
     * @return
     *     possible object is
     *     {@link Boolean }
     *     
     */
    public Boolean isIsContainer() {
        return isContainer;
    }

    /**
     * Sets the value of the isContainer property.
     * 
     * @param value
     *     allowed object is
     *     {@link Boolean }
     *     
     */
    public void setIsContainer(Boolean value) {
        this.isContainer = value;
    }

}
