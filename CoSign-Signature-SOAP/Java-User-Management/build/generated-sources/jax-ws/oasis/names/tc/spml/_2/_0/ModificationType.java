
package oasis.names.tc.spml._2._0;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;
import com.arx.sapiws.spml._1.GroupRecord;
import com.arx.sapiws.spml._1.UserRecord;


/**
 * <p>Java class for ModificationType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="ModificationType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ExtensibleType">
 *       &lt;sequence>
 *         &lt;element name="component" type="{urn:oasis:names:tc:SPML:2:0}SelectionType" minOccurs="0"/>
 *         &lt;element ref="{http://arx.com/SAPIWS/SPML/1.0}UserRecord" minOccurs="0"/>
 *         &lt;element ref="{http://arx.com/SAPIWS/SPML/1.0}GroupRecord" minOccurs="0"/>
 *         &lt;element name="capabilityData" type="{urn:oasis:names:tc:SPML:2:0}CapabilityDataType" maxOccurs="unbounded" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="modificationMode" type="{urn:oasis:names:tc:SPML:2:0}ModificationModeType" />
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "ModificationType", propOrder = {
    "component",
    "userRecord",
    "groupRecord",
    "capabilityData"
})
public class ModificationType
    extends ExtensibleType
{

    protected SelectionType component;
    @XmlElement(name = "UserRecord", namespace = "http://arx.com/SAPIWS/SPML/1.0")
    protected UserRecord userRecord;
    @XmlElement(name = "GroupRecord", namespace = "http://arx.com/SAPIWS/SPML/1.0")
    protected GroupRecord groupRecord;
    protected List<CapabilityDataType> capabilityData;
    @XmlAttribute(name = "modificationMode")
    protected ModificationModeType modificationMode;

    /**
     * Gets the value of the component property.
     * 
     * @return
     *     possible object is
     *     {@link SelectionType }
     *     
     */
    public SelectionType getComponent() {
        return component;
    }

    /**
     * Sets the value of the component property.
     * 
     * @param value
     *     allowed object is
     *     {@link SelectionType }
     *     
     */
    public void setComponent(SelectionType value) {
        this.component = value;
    }

    /**
     * Gets the value of the userRecord property.
     * 
     * @return
     *     possible object is
     *     {@link UserRecord }
     *     
     */
    public UserRecord getUserRecord() {
        return userRecord;
    }

    /**
     * Sets the value of the userRecord property.
     * 
     * @param value
     *     allowed object is
     *     {@link UserRecord }
     *     
     */
    public void setUserRecord(UserRecord value) {
        this.userRecord = value;
    }

    /**
     * Gets the value of the groupRecord property.
     * 
     * @return
     *     possible object is
     *     {@link GroupRecord }
     *     
     */
    public GroupRecord getGroupRecord() {
        return groupRecord;
    }

    /**
     * Sets the value of the groupRecord property.
     * 
     * @param value
     *     allowed object is
     *     {@link GroupRecord }
     *     
     */
    public void setGroupRecord(GroupRecord value) {
        this.groupRecord = value;
    }

    /**
     * Gets the value of the capabilityData property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the capabilityData property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getCapabilityData().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link CapabilityDataType }
     * 
     * 
     */
    public List<CapabilityDataType> getCapabilityData() {
        if (capabilityData == null) {
            capabilityData = new ArrayList<CapabilityDataType>();
        }
        return this.capabilityData;
    }

    /**
     * Gets the value of the modificationMode property.
     * 
     * @return
     *     possible object is
     *     {@link ModificationModeType }
     *     
     */
    public ModificationModeType getModificationMode() {
        return modificationMode;
    }

    /**
     * Sets the value of the modificationMode property.
     * 
     * @param value
     *     allowed object is
     *     {@link ModificationModeType }
     *     
     */
    public void setModificationMode(ModificationModeType value) {
        this.modificationMode = value;
    }

}
