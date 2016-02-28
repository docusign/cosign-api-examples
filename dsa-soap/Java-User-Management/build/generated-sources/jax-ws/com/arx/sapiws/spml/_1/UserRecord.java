
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlType;
import javax.xml.datatype.XMLGregorianCalendar;
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
 *       &lt;attribute name="UserLoginName" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="Password" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="UserCN" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="EmailAddress" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="RightsMask" use="required" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;attribute name="UserKind" type="{http://arx.com/SAPIWS/SPML/1.0}UserKindEnum" />
 *       &lt;attribute name="UpdateTime" type="{http://www.w3.org/2001/XMLSchema}dateTime" />
 *       &lt;attribute name="Guid" type="{http://www.w3.org/2001/XMLSchema}string" />
 *       &lt;attribute name="EnrollmentStatus" type="{http://arx.com/SAPIWS/SPML/1.0}EnrollmentStatusEnum" />
 *       &lt;attribute name="EnrollmentReason" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;attribute name="LoginStatus" type="{http://arx.com/SAPIWS/SPML/1.0}UserLoginEnum" />
 *       &lt;attribute name="Counter1" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;attribute name="Counter2" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;attribute name="Counter3" type="{http://www.w3.org/2001/XMLSchema}unsignedInt" />
 *       &lt;attribute name="UserCertStatus" type="{http://arx.com/SAPIWS/SPML/1.0}UserCertStatusEnum" />
 *       &lt;attribute name="CertRequestStatus" type="{http://arx.com/SAPIWS/SPML/1.0}PendingRequestStatusEnum" />
 *       &lt;attribute name="GroupName" type="{http://www.w3.org/2001/XMLSchema}string" />
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
@XmlRootElement(name = "UserRecord", namespace = "http://arx.com/SAPIWS/SPML/1.0")
public class UserRecord
    extends ExtensibleType
{

    @XmlAttribute(name = "UserLoginName")
    protected String userLoginName;
    @XmlAttribute(name = "Password")
    protected String password;
    @XmlAttribute(name = "UserCN")
    protected String userCN;
    @XmlAttribute(name = "EmailAddress")
    protected String emailAddress;
    @XmlAttribute(name = "RightsMask", required = true)
    @XmlSchemaType(name = "unsignedInt")
    protected long rightsMask;
    @XmlAttribute(name = "UserKind")
    protected UserKindEnum userKind;
    @XmlAttribute(name = "UpdateTime")
    @XmlSchemaType(name = "dateTime")
    protected XMLGregorianCalendar updateTime;
    @XmlAttribute(name = "Guid")
    protected String guid;
    @XmlAttribute(name = "EnrollmentStatus")
    protected EnrollmentStatusEnum enrollmentStatus;
    @XmlAttribute(name = "EnrollmentReason")
    @XmlSchemaType(name = "unsignedInt")
    protected Long enrollmentReason;
    @XmlAttribute(name = "LoginStatus")
    protected UserLoginEnum loginStatus;
    @XmlAttribute(name = "Counter1")
    @XmlSchemaType(name = "unsignedInt")
    protected Long counter1;
    @XmlAttribute(name = "Counter2")
    @XmlSchemaType(name = "unsignedInt")
    protected Long counter2;
    @XmlAttribute(name = "Counter3")
    @XmlSchemaType(name = "unsignedInt")
    protected Long counter3;
    @XmlAttribute(name = "UserCertStatus")
    protected UserCertStatusEnum userCertStatus;
    @XmlAttribute(name = "CertRequestStatus")
    protected PendingRequestStatusEnum certRequestStatus;
    @XmlAttribute(name = "GroupName")
    protected String groupName;

    /**
     * Gets the value of the userLoginName property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUserLoginName() {
        return userLoginName;
    }

    /**
     * Sets the value of the userLoginName property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUserLoginName(String value) {
        this.userLoginName = value;
    }

    /**
     * Gets the value of the password property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getPassword() {
        return password;
    }

    /**
     * Sets the value of the password property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setPassword(String value) {
        this.password = value;
    }

    /**
     * Gets the value of the userCN property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getUserCN() {
        return userCN;
    }

    /**
     * Sets the value of the userCN property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setUserCN(String value) {
        this.userCN = value;
    }

    /**
     * Gets the value of the emailAddress property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getEmailAddress() {
        return emailAddress;
    }

    /**
     * Sets the value of the emailAddress property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setEmailAddress(String value) {
        this.emailAddress = value;
    }

    /**
     * Gets the value of the rightsMask property.
     * 
     */
    public long getRightsMask() {
        return rightsMask;
    }

    /**
     * Sets the value of the rightsMask property.
     * 
     */
    public void setRightsMask(long value) {
        this.rightsMask = value;
    }

    /**
     * Gets the value of the userKind property.
     * 
     * @return
     *     possible object is
     *     {@link UserKindEnum }
     *     
     */
    public UserKindEnum getUserKind() {
        return userKind;
    }

    /**
     * Sets the value of the userKind property.
     * 
     * @param value
     *     allowed object is
     *     {@link UserKindEnum }
     *     
     */
    public void setUserKind(UserKindEnum value) {
        this.userKind = value;
    }

    /**
     * Gets the value of the updateTime property.
     * 
     * @return
     *     possible object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public XMLGregorianCalendar getUpdateTime() {
        return updateTime;
    }

    /**
     * Sets the value of the updateTime property.
     * 
     * @param value
     *     allowed object is
     *     {@link XMLGregorianCalendar }
     *     
     */
    public void setUpdateTime(XMLGregorianCalendar value) {
        this.updateTime = value;
    }

    /**
     * Gets the value of the guid property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getGuid() {
        return guid;
    }

    /**
     * Sets the value of the guid property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setGuid(String value) {
        this.guid = value;
    }

    /**
     * Gets the value of the enrollmentStatus property.
     * 
     * @return
     *     possible object is
     *     {@link EnrollmentStatusEnum }
     *     
     */
    public EnrollmentStatusEnum getEnrollmentStatus() {
        return enrollmentStatus;
    }

    /**
     * Sets the value of the enrollmentStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link EnrollmentStatusEnum }
     *     
     */
    public void setEnrollmentStatus(EnrollmentStatusEnum value) {
        this.enrollmentStatus = value;
    }

    /**
     * Gets the value of the enrollmentReason property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    public Long getEnrollmentReason() {
        return enrollmentReason;
    }

    /**
     * Sets the value of the enrollmentReason property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setEnrollmentReason(Long value) {
        this.enrollmentReason = value;
    }

    /**
     * Gets the value of the loginStatus property.
     * 
     * @return
     *     possible object is
     *     {@link UserLoginEnum }
     *     
     */
    public UserLoginEnum getLoginStatus() {
        return loginStatus;
    }

    /**
     * Sets the value of the loginStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link UserLoginEnum }
     *     
     */
    public void setLoginStatus(UserLoginEnum value) {
        this.loginStatus = value;
    }

    /**
     * Gets the value of the counter1 property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    public Long getCounter1() {
        return counter1;
    }

    /**
     * Sets the value of the counter1 property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setCounter1(Long value) {
        this.counter1 = value;
    }

    /**
     * Gets the value of the counter2 property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    public Long getCounter2() {
        return counter2;
    }

    /**
     * Sets the value of the counter2 property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setCounter2(Long value) {
        this.counter2 = value;
    }

    /**
     * Gets the value of the counter3 property.
     * 
     * @return
     *     possible object is
     *     {@link Long }
     *     
     */
    public Long getCounter3() {
        return counter3;
    }

    /**
     * Sets the value of the counter3 property.
     * 
     * @param value
     *     allowed object is
     *     {@link Long }
     *     
     */
    public void setCounter3(Long value) {
        this.counter3 = value;
    }

    /**
     * Gets the value of the userCertStatus property.
     * 
     * @return
     *     possible object is
     *     {@link UserCertStatusEnum }
     *     
     */
    public UserCertStatusEnum getUserCertStatus() {
        return userCertStatus;
    }

    /**
     * Sets the value of the userCertStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link UserCertStatusEnum }
     *     
     */
    public void setUserCertStatus(UserCertStatusEnum value) {
        this.userCertStatus = value;
    }

    /**
     * Gets the value of the certRequestStatus property.
     * 
     * @return
     *     possible object is
     *     {@link PendingRequestStatusEnum }
     *     
     */
    public PendingRequestStatusEnum getCertRequestStatus() {
        return certRequestStatus;
    }

    /**
     * Sets the value of the certRequestStatus property.
     * 
     * @param value
     *     allowed object is
     *     {@link PendingRequestStatusEnum }
     *     
     */
    public void setCertRequestStatus(PendingRequestStatusEnum value) {
        this.certRequestStatus = value;
    }

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

}
