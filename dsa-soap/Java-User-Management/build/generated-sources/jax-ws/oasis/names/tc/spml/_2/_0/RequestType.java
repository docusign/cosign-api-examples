
package oasis.names.tc.spml._2._0;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlAttribute;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlID;
import javax.xml.bind.annotation.XmlSchemaType;
import javax.xml.bind.annotation.XmlSeeAlso;
import javax.xml.bind.annotation.XmlType;
import javax.xml.bind.annotation.adapters.CollapsedStringAdapter;
import javax.xml.bind.annotation.adapters.XmlJavaTypeAdapter;
import com.arx.sapiws.spml._1.CoSignLogonData;
import oasis.names.tc.spml._2._0.password.ExpirePasswordRequestType;
import oasis.names.tc.spml._2._0.password.ResetPasswordRequestType;
import oasis.names.tc.spml._2._0.password.SetPasswordRequestType;
import oasis.names.tc.spml._2._0.password.ValidatePasswordRequestType;
import oasis.names.tc.spml._2._0.search.CloseIteratorRequestType;
import oasis.names.tc.spml._2._0.search.IterateRequestType;
import oasis.names.tc.spml._2._0.search.SearchRequestType;


/**
 * <p>Java class for RequestType complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="RequestType">
 *   &lt;complexContent>
 *     &lt;extension base="{urn:oasis:names:tc:SPML:2:0}ExtensibleType">
 *       &lt;sequence>
 *         &lt;element ref="{http://arx.com/SAPIWS/SPML/1.0}CoSignLogonData" minOccurs="0"/>
 *       &lt;/sequence>
 *       &lt;attribute name="requestID" type="{http://www.w3.org/2001/XMLSchema}ID" />
 *       &lt;attribute name="executionMode" type="{urn:oasis:names:tc:SPML:2:0}ExecutionModeType" />
 *       &lt;anyAttribute/>
 *     &lt;/extension>
 *   &lt;/complexContent>
 * &lt;/complexType>
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "RequestType", propOrder = {
    "coSignLogonData"
})
@XmlSeeAlso({
    SearchRequestType.class,
    IterateRequestType.class,
    CloseIteratorRequestType.class,
    ValidatePasswordRequestType.class,
    SetPasswordRequestType.class,
    ResetPasswordRequestType.class,
    ExpirePasswordRequestType.class,
    AddRequestType.class,
    LookupRequestType.class,
    ModifyRequestType.class,
    DeleteRequestType.class,
    ListTargetsRequestType.class
})
public class RequestType
    extends ExtensibleType
{

    @XmlElement(name = "CoSignLogonData", namespace = "http://arx.com/SAPIWS/SPML/1.0")
    protected CoSignLogonData coSignLogonData;
    @XmlAttribute(name = "requestID")
    @XmlJavaTypeAdapter(CollapsedStringAdapter.class)
    @XmlID
    @XmlSchemaType(name = "ID")
    protected String requestID;
    @XmlAttribute(name = "executionMode")
    protected ExecutionModeType executionMode;

    /**
     * Gets the value of the coSignLogonData property.
     * 
     * @return
     *     possible object is
     *     {@link CoSignLogonData }
     *     
     */
    public CoSignLogonData getCoSignLogonData() {
        return coSignLogonData;
    }

    /**
     * Sets the value of the coSignLogonData property.
     * 
     * @param value
     *     allowed object is
     *     {@link CoSignLogonData }
     *     
     */
    public void setCoSignLogonData(CoSignLogonData value) {
        this.coSignLogonData = value;
    }

    /**
     * Gets the value of the requestID property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getRequestID() {
        return requestID;
    }

    /**
     * Sets the value of the requestID property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setRequestID(String value) {
        this.requestID = value;
    }

    /**
     * Gets the value of the executionMode property.
     * 
     * @return
     *     possible object is
     *     {@link ExecutionModeType }
     *     
     */
    public ExecutionModeType getExecutionMode() {
        return executionMode;
    }

    /**
     * Sets the value of the executionMode property.
     * 
     * @param value
     *     allowed object is
     *     {@link ExecutionModeType }
     *     
     */
    public void setExecutionMode(ExecutionModeType value) {
        this.executionMode = value;
    }

}
