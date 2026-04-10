import random
import string

def generate_large_text_file(filename, size_mb=512):
    target_size = size_mb * 1024 * 1024  # Convert MB to bytes
    chunk_size = 1024 * 1024  # Write in 1 MB chunks
    chars = string.ascii_letters + string.digits + " \n"

    with open(filename, "w", encoding="utf-8") as f:
        written = 0
        while written < target_size:
            # Generate ~1 MB of random text
            chunk = ''.join(random.choice(chars) for _ in range(chunk_size))
            f.write(chunk)
            written += len(chunk)

    print(f"{filename} created with size {size_mb} MB.")

if __name__ == "__main__":
    generate_large_text_file("bigfile.txt", 512)
