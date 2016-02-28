
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for UserLoginEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="UserLoginEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="USER_LOGIN_STATUS_NONE"/>
 *     &lt;enumeration value="USER_LOGIN_STATUS_ENABLED"/>
 *     &lt;enumeration value="USER_LOGIN_STATUS_DISABLED"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "UserLoginEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum UserLoginEnum {

    USER_LOGIN_STATUS_NONE,
    USER_LOGIN_STATUS_ENABLED,
    USER_LOGIN_STATUS_DISABLED;

    public String value() {
        return name();
    }

    public static UserLoginEnum fromValue(String v) {
        return valueOf(v);
    }

}
