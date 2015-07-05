
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for UserCertStatusEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="UserCertStatusEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="USER_CERT_STATUS_NONE"/>
 *     &lt;enumeration value="USER_CERT_STATUS_EXIST"/>
 *     &lt;enumeration value="USER_CERT_STATUS_NOT_EXIST"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "UserCertStatusEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum UserCertStatusEnum {

    USER_CERT_STATUS_NONE,
    USER_CERT_STATUS_EXIST,
    USER_CERT_STATUS_NOT_EXIST;

    public String value() {
        return name();
    }

    public static UserCertStatusEnum fromValue(String v) {
        return valueOf(v);
    }

}
