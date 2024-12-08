const puppeteer = require("puppeteer")

async function testScreen() {
    console.log("Запуск браузера")
    const browser = await puppeteer.launch({ headless: false, slowMo: 100 })

    console.log("Открыть вкладку браузера")
    const page = await browser.newPage()

    console.log("Открыть страницу")
    await page.goto("http://localhost:3000/")

    console.log("Задать разрешение страницы")
    await page.setViewport({ width: 1080, height: 1024 })

    console.log("Сделать скриншот страницы")
    await page.screenshot({ path: "test1.png" })

    console.log("Закрыть браузер")
    await browser.close()
}

testScreen()