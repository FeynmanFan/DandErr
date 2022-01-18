class documentCard{
    title: string;
    contents: string;

    get length() {
        return this.contents.length;
    }

    constructor(title: string, contents: string) {
        this.title = title;
        this.contents = contents;
    }
}