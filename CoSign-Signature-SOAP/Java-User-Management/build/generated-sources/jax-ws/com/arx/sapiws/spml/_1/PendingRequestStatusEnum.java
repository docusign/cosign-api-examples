
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for PendingRequestStatusEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="PendingRequestStatusEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="PENDING_REQUEST_STATUS_NONE"/>
 *     &lt;enumeration value="PENDING_REQUEST_STATUS_SEND_CRQ"/>
 *     &lt;enumeration value="PENDING_REQUEST_STATUS_APPROVE"/>
 *     &lt;enumeration value="PENDING_REQUEST_STATUS_RETRIEVE_CERT"/>
 *     &lt;enumeration value="PENDING_REQUEST_STATUS_REVOKE"/>
 *     &lt;enumeration value="PENDING_REQUEST_STATUS_ALL"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "PendingRequestStatusEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum PendingRequestStatusEnum {

    PENDING_REQUEST_STATUS_NONE,
    PENDING_REQUEST_STATUS_SEND_CRQ,
    PENDING_REQUEST_STATUS_APPROVE,
    PENDING_REQUEST_STATUS_RETRIEVE_CERT,
    PENDING_REQUEST_STATUS_REVOKE,
    PENDING_REQUEST_STATUS_ALL;

    public String value() {
        return name();
    }

    public static PendingRequestStatusEnum fromValue(String v) {
        return valueOf(v);
    }

}
