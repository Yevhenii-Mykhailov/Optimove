package org.example;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class Main {
    public static void main(String[] args) {
        System.out.printf("Hello and welcome!");
        WebDriver driver = new ChromeDriver();


        driver.get("https://www.optimove.com/careers");


        }
    }