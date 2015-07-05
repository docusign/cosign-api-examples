
package com.arx.sapiws.spml._1;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for GroupKeySizeEnum.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="GroupKeySizeEnum">
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string">
 *     &lt;enumeration value="GROUP_DEFAULT_KEY"/>
 *     &lt;enumeration value="GROUP_NO_KEY"/>
 *     &lt;enumeration value="GROUP_KEY_1024"/>
 *     &lt;enumeration value="GROUP_KEY_2048"/>
 *     &lt;enumeration value="GROUP_KEY_4096"/>
 *   &lt;/restriction>
 * &lt;/simpleType>
 * </pre>
 * 
 */
@XmlType(name = "GroupKeySizeEnum", namespace = "http://arx.com/SAPIWS/SPML/1.0")
@XmlEnum
public enum GroupKeySizeEnum {

    GROUP_DEFAULT_KEY,
    GROUP_NO_KEY,
    GROUP_KEY_1024,
    GROUP_KEY_2048,
    GROUP_KEY_4096;

    public String value() {
        return name();
    }

    public static GroupKeySizeEnum fromValue(String v) {
        return valueOf(v);
    }

}
