async function main() {
    const fs = require("fs/promises");
    const data = await fs.readFile("data.txt", "utf-8");
    console.log(data);
}

main();
