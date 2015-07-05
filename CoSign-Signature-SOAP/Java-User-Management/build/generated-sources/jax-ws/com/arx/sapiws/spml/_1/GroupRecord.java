
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import oasis.names.tc.spml._2._0.ExtensibleType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType>
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ExtensibleType">
 *       &lt;attribute name="GroupName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="Address" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="PhoneNumber" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="Country" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="DomainName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="OrganizationName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="OrganizationUnitName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="KeySize" type="{http://arx.com/SAPIWS/SPML/1.0}GroupKeySizeEnum" />
 *       &lt;attribute name="GroupStatus" type="{http://arx.com/SAPIWS/SPML/1.0}GroupStatusEnum" />
 *       &lt;attribute name="PackagesMask" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;attribute name="FlagsMask" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "")
@XmlRootElement(name = "GroupRecord", namespace = "http://arx.com/SAPIWS/SPML/1.0")
public class GroupRecord
    extends ExtensibleType
{

    @XmlAttribute(name = "GroupName")
    protected String groupName;
    @XmlAttribute(name = "Address")
    protected String address;
    @XmlAttribute(name = "PhoneNumber")
    protected String phoneNumber;
    @XmlAttribute(name = "Country")
    protected String country;
    @XmlAttribute(name = "DomainName")
    protected String domainName;
    @XmlAttribute(name = "OrganizationName")
    protected String organizationName;
    @XmlAttribute(name = "OrganizationUnitName")
    protected String organizationUnitName;
    @XmlAttribute(name = "KeySize")
    protected GroupKeySizeEnum keySize;
    @XmlAttribute(name = "GroupStatus")
    protected GroupStatusEnum groupStatus;
    @XmlAttribute(name = "PackagesMask")
    @XmlSchemaType(name = "unsignedInt")
    protected Long packagesMask;
    @XmlAttribute(name = "FlagsMask")
    @XmlSchemaType(name = "unsignedInt")
    protected Long flagsMask;

    /**
     * Gets the value of the groupName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getGroupName() {
        return groupName;
    }

    /**
     * Sets the value of the groupName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGroupName(String value) {
        this.groupName = value;
    }

    /**
     * Gets the value of the address property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getAddress() {
        return address;
    }

    /**
     * Sets the value of the address property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setAddress(String value) {
        this.address = value;
    }

    /**
     * Gets the value of the phoneNumber property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getPhoneNumber() {
        return phoneNumber;
    }

    /**
     * Sets the value of the phoneNumber property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPhoneNumber(String value) {
        this.phoneNumber = value;
    }

    /**
     * Gets the value of the country property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getCountry() {
        return country;
    }

    /**
     * Sets the value of the country property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setCountry(String value) {
        this.country = value;
    }

    /**
     * Gets the value of the domainName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getDomainName() {
        return domainName;
    }

    /**
     * Sets the value of the domainName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setDomainName(String value) {
        this.domainName = value;
    }

    /**
     * Gets the value of the organizationName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOrganizationName() {
        return organizationName;
    }

    /**
     * Sets the value of the organizationName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganizationName(String value) {
        this.organizationName = value;
    }

    /**
     * Gets the value of the organizationUnitName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getOrganizationUnitName() {
        return organizationUnitName;
    }

    /**
     * Sets the value of the organizationUnitName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setOrganizationUnitName(String value) {
        this.organizationUnitName = value;
    }

    /**
     * Gets the value of the keySize property.
     * 
     * @return
     *     possible object is
     *     {@link GroupKeySizeEnum }
     *     
     */
    public GroupKeySizeEnum getKeySize() {
        return keySize;
    }

    /**
     * Sets the value of the keySize property.
     * 
     * @param value
     *     allowed object is
     *     {@link GroupKeySizeEnum }
     *     
     */
    public void setKeySize(GroupKeySizeEnum value) {
        this.keySize = value;
    }

    /**
     * Gets the value of the groupStatus property.
     * 
     * @return
     *     possible object is
     *     {@link GroupStatusEnum }
     *     
     */
    public GroupStatusEnum getGroupStatus() {
        return groupStatus;
    }

    /**
     * Sets the value of the groupStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link GroupStatusEnum }
     *     
     */
    public void setGroupStatus(GroupStatusEnum value) {
        this.groupStatus = value;
    }

    /**
     * Gets the value of the packagesMask property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    public Long getPackagesMask() {
        return packagesMask;
    }

    /**
     * Sets the value of the packagesMask property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setPackagesMask(Long value) {
        this.packagesMask = value;
    }

    /**
     * Gets the value of the flagsMask property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    public Long getFlagsMask() {
        return flagsMask;
    }

    /**
     * Sets the value of the flagsMask property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setFlagsMask(Long value) {
        this.flagsMask = value;
    }

}
