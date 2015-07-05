
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GroupStatusEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="GroupStatusEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="GROUP_STATUS_NONE"/>
 *     &lt;enumeration value="GROUP_STATUS_ENABLED"/>
 *     &lt;enumeration value="GROUP_STATUS_DISABLED"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "GroupStatusEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum GroupStatusEnum {

    GROUP_STATUS_NONE,
    GROUP_STATUS_ENABLED,
    GROUP_STATUS_DISABLED;

    public String value() {
        return name();
    }

    public static GroupStatusEnum fromValue(String v) {
        return valueOf(v);
    }

}
